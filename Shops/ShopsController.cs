using Gusto.Models;
using Gusto.Products;
using Gusto.Shops;
using Gusto.Shops.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ShopsController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly GustoContext _context;
    private readonly ShopAuthUtility _shopAuthUtility;

    public ShopsController(
        IConfiguration configuration,
        GustoContext context, 
        ShopAuthUtility shopAuthUtility)
    {
        _configuration = configuration;
        _context = context;
        _shopAuthUtility = shopAuthUtility;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<Shop>> PostShop([FromBody] ShopCreateRequest shopRequest)
    {
        // Vérifier si l'email ou le nom existe déjà
        if (await _context.Shops.AnyAsync(s => s.Email == shopRequest.Email))
            return BadRequest("Email déjà utilisé");
        if (await _context.Shops.AnyAsync(s => s.Name == shopRequest.Name))
            return BadRequest("Nom déjà utilisé");

        var shop = new Shop
        {
            Name = shopRequest.Name,
            Email = shopRequest.Email,
            Password = _shopAuthUtility.GetHashedPassword(shopRequest.Password), // hashage du mot de passe
            Status = ShopStatus.Active, // activation du compte
            Products = new List<Product>()
        };

        _context.Shops.Add(shop);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch
        {
            return BadRequest("Inscription désactivée");
        }

        return CreatedAtAction(nameof(GetShop), new { id = shop.ShopId }, shop);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Shop>> GetShop(int id)
    {
        var shop = await _context.Shops.FindAsync(id);
        if (shop == null)
        {
            return NotFound();
        }
        shop.Password = null; // évite de renvoyer le mot de passe (même hashé)
        return shop;
    }

    [HttpPost("connect")]
    [AllowAnonymous]
    public async Task<IActionResult> ConnectShop([FromBody] ShopConnectionInfo connectionInfo)
    {
        var shop = await _context.Shops.FirstOrDefaultAsync(s => s.Email == connectionInfo.Email);

        if (shop == null || !VerifyPassword(shop.Password, connectionInfo.Password))
        {
            return Unauthorized("Informations de connexion incorrectes");
        }

        // Création du token JWT
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, shop.ShopId.ToString()),
            new Claim(ClaimTypes.Email, shop.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(1);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: expires,
            signingCredentials: creds
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(new { Token = tokenString });
    }

    private bool VerifyPassword(string hashedPassword, string password)
    {
        return hashedPassword == _shopAuthUtility.GetHashedPassword(password);
    }

}

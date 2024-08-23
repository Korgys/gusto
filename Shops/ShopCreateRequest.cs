using System.ComponentModel.DataAnnotations;

namespace Gusto.Shops;

public class ShopCreateRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    [MinLength(8)] // Taille minimale du mot de passe
    public string Password { get; set; }
}

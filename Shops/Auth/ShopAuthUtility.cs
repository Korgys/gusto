using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Gusto.Shops.Auth;

public class ShopAuthUtility
{
    private readonly byte[] _salt;

    public ShopAuthUtility(IConfiguration configuration)
    {
        var saltString = configuration["ShopAuthentificationSalt"];
        // Conversion du string en tableau d'octets
        _salt = System.Text.Encoding.UTF8.GetBytes(saltString);
    }

    public string GetHashedPassword(string password)
    {
        // Utilise le sel de la configuration
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: _salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
    }
}

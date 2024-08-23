using Gusto.Products;

namespace Gusto.Shops;

public class Shop
{
    public int ShopId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ShopStatus Status { get; set; }
    public List<Product> Products { get; set; }
}

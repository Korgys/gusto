using Gusto.Shops;

namespace Gusto.Products;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int ShopId { get; set; }
    public Shop Shop { get; set; }
}

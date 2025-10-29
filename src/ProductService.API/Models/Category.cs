namespace ProductService.API.Models;

public class Category
{
    public int CategoryID { get; set; }
    public string CategoryName { get; set; } = default!;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}

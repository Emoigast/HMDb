namespace HMDb.Models;

public class ProductType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ProductCategory ProductCategory { get; set; }

    public ProductType(int id, string name, ProductCategory productCategory)
    {
        Id = id;
        Name = name;
        ProductCategory = productCategory;
    }
}

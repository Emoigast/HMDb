namespace HMDb.Models;

public class ProduktKategori
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ProduktKategori ProductCategory { get; set; }


    public ProduktKategori(int id, string name, ProduktKategori productCategory)
    {
        Id = id;
        Name = name;
        ProductCategory = productCategory;
    }
}

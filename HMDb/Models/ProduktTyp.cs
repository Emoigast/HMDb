namespace HMDb.Models;

public class ProduktTyp
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ProduktKategori ProductCategory { get; set; }

    public ProduktTyp(int id, string name, ProduktKategori productCategory)
    {
        Id = id;
        Name = name;
        ProductCategory = productCategory;
    }
}

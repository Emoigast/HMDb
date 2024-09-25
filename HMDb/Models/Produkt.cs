namespace HMDb.Models;

public class Produkt
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ProduktTyp ProductType { get; set; }

    public Produkt(int id, string name, ProduktTyp productType)
    {
        Id = id;
        Name = name;
        ProductType = productType;
    }
}

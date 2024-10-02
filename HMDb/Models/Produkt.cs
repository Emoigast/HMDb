namespace HMDb.Models;

public class Produkt
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ProduktTyp ProductType { get; set; }
}

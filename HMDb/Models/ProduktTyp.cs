namespace HMDb.Models;

public class ProduktTyp
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ProduktKategori ProductCategory { get; set; }
}

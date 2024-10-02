namespace HMDb.Models;

public class ProduktKategori
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ProduktKategori? ProductCategory { get; set; }
}

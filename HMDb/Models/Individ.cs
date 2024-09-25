namespace HMDb.Models;

public class Individ : Produkt
{
    public string SerialNumber { get; set; }

    public Individ(int id, string name, ProduktTyp productType, string serialNumber) : base(id, name, productType)
    {
        SerialNumber = serialNumber;
    }
}

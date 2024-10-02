using HMDb.Models;

namespace HMDb.Data;

public interface IProduktKategoriData
{
    Task<List<ProduktKategori>> GetProductCategories();
    Task CreateProductCategory(ProduktKategori productCategory);
}

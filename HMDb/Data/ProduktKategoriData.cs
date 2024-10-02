using HMDb.DbAccess;
using HMDb.Models;

namespace HMDb.Data;

public class ProduktKategoriData : IProduktKategoriData
{
    private readonly ISqlDataAccess _sql;

    public ProduktKategoriData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    public async Task<List<ProduktKategori>> GetProductCategories()
    {
        string sql = "SELECT Id, Name FROM ProduktKategori";

        IEnumerable<ProduktKategori> productCategories = await _sql.LoadData<ProduktKategori, dynamic>(sql, new { });

        return productCategories.ToList();
    }

    public async Task CreateProductCategory(ProduktKategori productCategory)
    {
        string sql = "INSERT INTO ProduktKategori (Name) VALUES (@Name)";

        await _sql.SaveData(sql, new { productCategory.Name });
    }
}

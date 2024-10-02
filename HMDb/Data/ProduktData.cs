using HMDb.DbAccess;
using HMDb.Models;

namespace HMDb.Data;

public class ProduktData
{
    private readonly ISqlDataAccess _sql;

    public ProduktData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    public async Task<List<Produkt>> GetProducts()
    {
        string sql = "";

        IEnumerable<Produkt> products = await _sql.LoadData<Produkt, dynamic>(sql, new { });

        return products.ToList();
    }

    public async Task CreateProduct(Produkt product)
    {
        string sql = "";

        await _sql.SaveData(sql, new { });
    }
}

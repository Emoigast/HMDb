using HMDb.DbAccess;
using HMDb.Models;

namespace HMDb.Data;

public class ProductTypeData
{
    private readonly ISqlDataAccess _sql;

    public ProductTypeData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    public async Task<List<ProductType>> GetProducts()
    {
        string sql = "SELECT Id, Name FROM ProductType";

        IEnumerable<ProductType> products = await _sql.LoadData<ProductType, dynamic>(sql, new { });

        return products.ToList();
    }

    public async Task CreateProduct(ProductType product)
    {
        string sql = "";

        await _sql.SaveData(sql, new { });
    }
}

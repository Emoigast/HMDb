using HMDb.DbAccess;
using HMDb.Models;

namespace HMDb.Data;

public class ProductTypeData : IProductTypeData
{
    private readonly ISqlDataAccess _sql;

    public ProductTypeData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    public async Task<List<ProductType>> GetProductTypes()
    {
        string sql = "SELECT Id, Name FROM ProductType";

        IEnumerable<ProductType> productTypes = await _sql.LoadData<ProductType, dynamic>(sql, new { });

        return productTypes.ToList();
    }

    public async Task CreateProductType(ProductType productType)
    {
        string sql = "INSERT INTO ProductType (Name) VALUES (@Name)";

        await _sql.SaveData(sql, new { productType.Name });
    }

    public async Task UpdateProductType(ProductType productType)
    {
        string sql = "UPDATE ProductType SET Name = @Name WHERE Id = @Id";

        await _sql.SaveData(sql, new { productType.Id, productType.Name });
    }

    public async Task DeleteProductType(int productTypeId)
    {
        string sql = "DELETE FROM ProductType WHERE Id = @productTypeId";

        await _sql.SaveData(sql, new { productTypeId });
    }
}

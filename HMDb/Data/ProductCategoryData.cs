using HMDb.DbAccess;
using HMDb.Models;

namespace HMDb.Data;

public class ProductCategoryData : IProductCategoryData
{
    private readonly ISqlDataAccess _sql;

    public ProductCategoryData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    public async Task<List<ProductCategory>> GetProductCategories()
    {
        string sql = "SELECT Id, Name FROM ProductCategory";

        IEnumerable<ProductCategory> productCategories = await _sql.LoadData<ProductCategory, dynamic>(sql, new { });

        return productCategories.ToList();
    }

    public async Task CreateProductCategory(ProductCategory productCategory)
    {
        string sql = "INSERT INTO ProductCategory (Name) VALUES (@Name)";

        await _sql.SaveData(sql, new { productCategory.Name });
    }

    public async Task UpdateProductCategory(ProductCategory productCategory)
    {
        string sql = "UPDATE ProductCategory SET Name = @Name WHERE Id = @Id";

        await _sql.SaveData(sql, new { productCategory.Id, productCategory.Name });
    }

    public async Task DeleteProductCategory(int productCategoryId)
    {
        string sql = "DELETE FROM ProductCategory WHERE Id = @productCategoryId";

        await _sql.SaveData(sql, new { productCategoryId });
    }
}

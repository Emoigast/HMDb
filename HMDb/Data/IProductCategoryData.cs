using HMDb.Models;

namespace HMDb.Data;

public interface IProductCategoryData
{
    Task<List<ProductCategory>> GetProductCategories();
    Task CreateProductCategory(ProductCategory productCategory);
    Task DeleteProductCategory(int productCategoryId);
}

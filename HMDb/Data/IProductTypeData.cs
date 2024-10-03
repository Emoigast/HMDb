using HMDb.Models;

namespace HMDb.Data;

public interface IProductTypeData
{
    Task<List<ProductType>> GetProductTypes();
    Task CreateProductType(ProductType productType);
    Task UpdateProductType(ProductType productType);
    Task DeleteProductType(int productTypeId);
}

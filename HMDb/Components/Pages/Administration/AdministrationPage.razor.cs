using HMDb.Models;

namespace HMDb.Components.Pages.Administration;

public partial class AdministrationPage
{
    private IEnumerable<ProductCategory>? _productCategory = [];
    private int _productCategoryCount;

    private IEnumerable<ProductType>? _productType = [];
    private int _productTypeCount;

    private int _inventoryCount;

    protected override async Task OnInitializedAsync()
    {
        _productCategory = await db_ProductCategoryData.GetProductCategories();
        _productCategoryCount = _productCategory.Count();

        _productType = await db_ProductTypeData.GetProductTypes();
        _productTypeCount = _productType.Count();
    }
}

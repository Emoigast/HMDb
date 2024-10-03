using HMDb.Models;

namespace HMDb.Components.Pages.Administration;

public partial class AdministrationPage
{
    private IEnumerable<ProductCategory>? _productCategory = [];
    private int _productCategoryCount;

    protected override async Task OnInitializedAsync()
    {
        _productCategory = await db_ProductCategoryData.GetProductCategories();
        _productCategoryCount = _productCategory.Count();
    }
}

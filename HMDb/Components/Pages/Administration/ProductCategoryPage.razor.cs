using HMDb.Models;
using MudBlazor;

namespace HMDb.Components.Pages.Administration;

public partial class ProductCategoryPage
{
    private MudForm form;

    private IEnumerable<ProductCategory>? _productCategory = [];
    private string _productCategoryName = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await GetProductCategories();
    }

    private async Task GetProductCategories()
    {
        _productCategory = await db_ProduktKategoriData.GetProductCategories();
    }

    private async Task CreateProductCategory()
    {
        await form.Validate();

        if (form.IsValid)
        {

            await db_ProduktKategoriData.CreateProductCategory(new ProductCategory
            {
                Name = _productCategoryName,
            });

            _productCategoryName = string.Empty;

            await GetProductCategories();
        }
    }

    private async Task DeleteProductCategory(ProductCategory productCategory)
    {
        await db_ProduktKategoriData.DeleteProductCategory(productCategory.Id);

        await GetProductCategories();
    }

    private string ValidateName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return "Product category name is required";
        }

        return null;
    }

    private async Task OpenDialog()
    {

    }
}

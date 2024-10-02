using HMDb.Models;
using MudBlazor;

namespace HMDb.Components.Pages;

public partial class Home
{
    private MudForm form;
    private bool isValid;

    private IEnumerable<ProduktKategori>? _productCategory = [];
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

            await db_ProduktKategoriData.CreateProductCategory(new ProduktKategori
            {
                Name = _productCategoryName,
            });

            _productCategoryName = string.Empty;

            await GetProductCategories();
        }
    }

    private string ValidateName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return "Product category name is required";
        }

        return null;
    }
}

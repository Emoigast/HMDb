using HMDb.Models;

namespace HMDb.Components.Pages;

public partial class Home
{
    private IEnumerable<ProduktKategori>? _productCategory = [];

    protected override async Task OnInitializedAsync()
    {
        _productCategory = await db_ProduktKategoriData.GetProductCategories();
    }

    private string _productCategoryName = string.Empty;

    private async void CreateProductCategory()
    {
        await db_ProduktKategoriData.CreateProductCategory(new ProduktKategori
        {
            Name = _productCategoryName,
        });
    }
}

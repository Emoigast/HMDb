using HMDb.Components.Dialogs.ProductCategoryDialogs;
using HMDb.Models;
using Microsoft.AspNetCore.Components;
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
        _productCategory = await db_ProductCategoryData.GetProductCategories();
    }

    private async Task<IDialogReference> OpenCreateProductCategoryDialog()
    {
        var parameters = new DialogParameters<CreateProductCategoryDialog>
        {
            { x => x.TitleContent, "Create new product category" },
            { x => x.ButtonText, "Create new" },
            { x => x.GetProductCategories, EventCallback.Factory.Create(this, GetProductCategories) }
        };

        return await DialogService.ShowAsync<CreateProductCategoryDialog>(null, parameters);
    }

    private async Task<IDialogReference> OpenEditProductCategoryDialog(ProductCategory productCategory)
    {
        var parameters = new DialogParameters<UpdateProductCategoryDialog>
        {
            { x => x.TitleContent, "Edit product category" },
            { x => x.ButtonText, "Save changes" },
            { x => x.GetProductCategories, EventCallback.Factory.Create(this, GetProductCategories) },
            { x => x.SelectedProductCategory, productCategory }
        };

        return await DialogService.ShowAsync<UpdateProductCategoryDialog>(null, parameters);
    }

    private async Task OnProductCategoryCreated()
    {
        await GetProductCategories();
    }

    private async Task DeleteProductCategory(ProductCategory productCategory)
    {
        await db_ProductCategoryData.DeleteProductCategory(productCategory.Id);

        await GetProductCategories();
    }
}

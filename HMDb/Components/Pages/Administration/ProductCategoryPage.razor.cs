using HMDb.Components.Dialogs.ProductCategoryDialogs;
using HMDb.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HMDb.Components.Pages.Administration;

public partial class ProductCategoryPage
{
    private IEnumerable<ProductCategory>? _productCategory = [];

    protected override async Task OnInitializedAsync()
    {
        await GetProductCategories();
    }

    private async Task GetProductCategories()
    {
        _productCategory = await db_ProductCategoryData.GetProductCategories();
        _productCategory = _productCategory.OrderBy(productCategory => productCategory.Id);
    }

    private async Task<IDialogReference> OpenCreateProductCategoryDialog()
    {
        var parameters = new DialogParameters<CreateProductCategoryDialog>
        {
            { x => x.TitleContent, "Create product category" },
            { x => x.ButtonText, "Create" },
            { x => x.GetProductCategories, EventCallback.Factory.Create(this, GetProductCategories) }
        };

        return await DialogService.ShowAsync<CreateProductCategoryDialog>(null, parameters);
    }

    private async Task<IDialogReference> OpenUpdateProductCategoryDialog(ProductCategory productCategory)
    {
        var parameters = new DialogParameters<UpdateProductCategoryDialog>
        {
            { x => x.TitleContent, "Update product category" },
            { x => x.ButtonText, "Update" },
            { x => x.GetProductCategories, EventCallback.Factory.Create(this, GetProductCategories) },
            { x => x.SelectedProductCategory, productCategory }
        };

        return await DialogService.ShowAsync<UpdateProductCategoryDialog>(null, parameters);
    }

    private async Task<IDialogReference> OpenDeleteProductCategoryDialog(ProductCategory productCategory)
    {
        var parameters = new DialogParameters<DeleteProductCategoryDialog>
        {
            { x => x.TitleContent, "Delete product category" },
            { x => x.ButtonText, "Delete" },
            { x => x.GetProductCategories, EventCallback.Factory.Create(this, GetProductCategories) },
            { x => x.SelectedProductCategory, productCategory }
        };

        return await DialogService.ShowAsync<DeleteProductCategoryDialog>(null, parameters);
    }
}

using HMDb.Components.Dialogs.ProductTypeDialogs;
using HMDb.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HMDb.Components.Pages.Administration;

public partial class ProductTypePage
{
    private IEnumerable<ProductType>? _productType = [];

    protected override async Task OnInitializedAsync()
    {
        await GetProductTypes();
    }

    private async Task GetProductTypes()
    {
        _productType = await db_ProductTypeData.GetProductTypes();
        _productType = _productType.OrderBy(productType => productType.Id);
    }

    private async Task<IDialogReference> OpenCreateProductTypeDialog()
    {
        var parameters = new DialogParameters<CreateProductTypeDialog>
        {
            { x => x.TitleContent, "Create product type" },
            { x => x.ButtonText, "Create" },
            { x => x.GetProductTypes, EventCallback.Factory.Create(this, GetProductTypes) }
        };

        return await DialogService.ShowAsync<CreateProductTypeDialog>(null, parameters);
    }

    private async Task<IDialogReference> OpenUpdateProductTypeDialog(ProductType productType)
    {
        var parameters = new DialogParameters<UpdateProductTypeDialog>
        {
            { x => x.TitleContent, "Update product type" },
            { x => x.ButtonText, "Update" },
            { x => x.GetProductTypes, EventCallback.Factory.Create(this, GetProductTypes) },
            { x => x.SelectedProductType, productType }
        };

        return await DialogService.ShowAsync<UpdateProductTypeDialog>(null, parameters);
    }

    private async Task<IDialogReference> OpenDeleteProductTypeDialog(ProductType productType)
    {
        var parameters = new DialogParameters<DeleteProductTypeDialog>
        {
            { x => x.TitleContent, "Delete product type" },
            { x => x.ButtonText, "Delete" },
            { x => x.GetProductTypes, EventCallback.Factory.Create(this, GetProductTypes) },
            { x => x.SelectedProductType, productType }
        };

        return await DialogService.ShowAsync<DeleteProductTypeDialog>(null, parameters);
    }
}

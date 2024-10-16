using HMDb.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HMDb.Components.Dialogs.ProductTypeDialogs;

public partial class CreateProductTypeDialog
{
    [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }
    [Parameter] public string? TitleContent { get; set; }
    [Parameter] public string? ButtonText { get; set; }
    [Parameter] public EventCallback GetProductTypes { get; set; }

    private MudForm? form;

    private string? _productTypeName = string.Empty;

    private IEnumerable<ProductCategory> _productCategories = new List<ProductCategory>();
    private int _selectedCategoryId = 1;

    protected override async Task OnInitializedAsync()
    {
        _productCategories = await db_ProductCategoryData.GetProductCategories();
        _productCategories = _productCategories.OrderBy(productCategory => productCategory.Id);
    }

    private void Submit() => MudDialog?.Close(DialogResult.Ok(true));
    private void Cancel() => MudDialog?.Cancel();
    private void ToggleFullScreen() => DialogHelper.ToggleFullScreen(MudDialog);

private string ValidateName(string value)
{
    if (string.IsNullOrWhiteSpace(value))
    {
        return "Product type name is required";
    }

    return null;
}

private async Task CreateProductType()
{
    if (form != null)
    {
        await form.Validate();
    }

    if (form?.IsValid == true)
    {
        await db_ProductTypeData.CreateProductType(new ProductType
        {
            Name = _productTypeName?.Trim(),
            ProductCategoryId = _selectedCategoryId
        });

        if (GetProductTypes.HasDelegate)
        {
            await GetProductTypes.InvokeAsync();
        }

        Submit();
    }
}
}

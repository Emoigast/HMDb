using HMDb.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HMDb.Components.Dialogs.ProductCategoryDialogs;

public partial class CreateProductCategoryDialog
{
    [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }
    [Parameter] public string? TitleContent { get; set; }
    [Parameter] public string? ButtonText { get; set; }
    [Parameter] public EventCallback GetProductCategories { get; set; }

    private MudForm form;

    private string? _productCategoryName = string.Empty;

    private void Submit() => MudDialog?.Close(DialogResult.Ok(true));
    private void Cancel() => MudDialog?.Cancel();

    private void ToggleFullScreen()
    {
        if (MudDialog != null)
        {
            MudDialog.Options.FullScreen = !(MudDialog.Options.FullScreen ?? false);
            MudDialog.SetOptions(MudDialog.Options);
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

    private async Task CreateProductCategory()
    {
        await form.Validate();

        if (form.IsValid)
        {
            await db_ProductCategoryData.CreateProductCategory(new ProductCategory
            {
                Name = _productCategoryName?.Trim(),
            });

            if (GetProductCategories.HasDelegate)
            {
                await GetProductCategories.InvokeAsync();
            }

            Submit();
        }
    }
}

using HMDb.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HMDb.Components.Dialogs.ProductCategoryDialogs;

public partial class UpdateProductCategoryDialog
{
    [CascadingParameter]
    private MudDialogInstance? MudDialog { get; set; }

    [Parameter] public string? TitleContent { get; set; }
    [Parameter] public string? ButtonText { get; set; }
    [Parameter] public EventCallback GetProductCategories { get; set; }
    [Parameter] public ProductCategory SelectedProductCategory { get; set; } = new();

    private MudForm form;

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

    private async Task UpdateProductCategory()
    {
        await form.Validate();

        if (form.IsValid)
        {
            SelectedProductCategory.Name = SelectedProductCategory.Name?.Trim();
            await db_ProductCategoryData.UpdateProductCategory(SelectedProductCategory);

            if (GetProductCategories.HasDelegate)
            {
                await GetProductCategories.InvokeAsync();
            }

            Submit();
        }
    }
}

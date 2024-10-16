using HMDb.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HMDb.Components.Dialogs.ProductCategoryDialogs;

public partial class DeleteProductCategoryDialog
{
    [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }
    [Parameter] public string? TitleContent { get; set; }
    [Parameter] public string? ButtonText { get; set; }
    [Parameter] public EventCallback GetProductCategories { get; set; }
    [Parameter] public ProductCategory SelectedProductCategory { get; set; } = new();

    private MudForm form;

    private void Submit() => MudDialog?.Close(DialogResult.Ok(true));
    private void Cancel() => MudDialog?.Cancel();
    private void ToggleFullScreen() => DialogHelper.ToggleFullScreen(MudDialog);

    private async Task DeleteProductCategory()
    {
        await db_ProductCategoryData.DeleteProductCategory(SelectedProductCategory.Id);

        if (GetProductCategories.HasDelegate)
        {
            await GetProductCategories.InvokeAsync();
        }

        Submit();
    }
}

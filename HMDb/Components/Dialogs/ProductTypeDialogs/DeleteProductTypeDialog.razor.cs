using HMDb.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HMDb.Components.Dialogs.ProductTypeDialogs;

public partial class DeleteProductTypeDialog
{
    [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }
    [Parameter] public string? TitleContent { get; set; }
    [Parameter] public string? ButtonText { get; set; }
    [Parameter] public EventCallback GetProductTypes { get; set; }
    [Parameter] public ProductType SelectedProductType { get; set; } = new();

    private MudForm form;

    private void Submit() => MudDialog?.Close(DialogResult.Ok(true));
    private void Cancel() => MudDialog?.Cancel();
    private void ToggleFullScreen() => DialogHelper.ToggleFullScreen(MudDialog);

    private async Task DeleteProductType()
    {
        await db_ProductTypeData.DeleteProductType(SelectedProductType.Id);

        if (GetProductTypes.HasDelegate)
        {
            await GetProductTypes.InvokeAsync();
        }

        Submit();
    }
}

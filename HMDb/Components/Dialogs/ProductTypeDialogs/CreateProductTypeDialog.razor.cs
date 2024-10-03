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

    private MudForm form;

    private string? _productTypeName = string.Empty;

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
            return "Product type name is required";
        }

        return null;
    }

    private async Task CreateProductType()
    {
        await form.Validate();

        if (form.IsValid)
        {
            await db_ProductTypeData.CreateProductType(new ProductType
            {
                Name = _productTypeName?.Trim(),
            });

            if (GetProductTypes.HasDelegate)
            {
                await GetProductTypes.InvokeAsync();
            }

            Submit();
        }
    }
}

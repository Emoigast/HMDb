﻿using HMDb.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HMDb.Components.Dialogs.ProductTypeDialogs;

public partial class UpdateProductTypeDialog
{
    [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }
    [Parameter] public string? TitleContent { get; set; }
    [Parameter] public string? ButtonText { get; set; }
    [Parameter] public EventCallback GetProductTypes { get; set; }
    [Parameter] public ProductType SelectedProductType { get; set; } = new();

    private MudForm? form;

    private IEnumerable<ProductCategory> _productCategories = new List<ProductCategory>();
    private int _selectedCategoryId;

    protected override async Task OnInitializedAsync()
    {
        _productCategories = await db_ProductCategoryData.GetProductCategories();
        _productCategories = _productCategories.OrderBy(productCategory => productCategory.Id);
        _selectedCategoryId = SelectedProductType.ProductCategoryId;
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

    private async Task UpdateProductType()
    {
        await form.Validate();

        if (form.IsValid)
        {
            SelectedProductType.Name = SelectedProductType.Name?.Trim();
            SelectedProductType.ProductCategoryId = _selectedCategoryId;
            await db_ProductTypeData.UpdateProductType(SelectedProductType);

            if (GetProductTypes.HasDelegate)
            {
                await GetProductTypes.InvokeAsync();
            }

            Submit();
        }
    }
}

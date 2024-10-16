using MudBlazor;

namespace HMDb.Components.Dialogs;

public static class DialogHelper
{
    public static void ToggleFullScreen(MudDialogInstance? mudDialog)
    {
        if (mudDialog != null)
        {
            mudDialog.Options.FullScreen = !(mudDialog.Options.FullScreen ?? false);
            mudDialog.SetOptions(mudDialog.Options);
        }
    }
}

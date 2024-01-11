using Microsoft.Maui.Controls.Platform.Compatibility;
using ModalTest.Pages;

namespace ModalTest.Renderers;

public class CustomToolbarAppearanceTracker : IShellToolbarAppearanceTracker
{
    public void Dispose()
    {
    }

    public void SetAppearance(AndroidX.AppCompat.Widget.Toolbar toolbar, IShellToolbarTracker toolbarTracker, ShellAppearance appearance)
    {
        var currentPage = Shell.Current.CurrentPage;
        if (currentPage is not NavigationBarPage)
        {
            return;
        }

        toolbar.SetPadding(16, 0, 16, 0);

        if (toolbarTracker.CanNavigateBack)
        {
            toolbar.NavigationIcon = null;
        }
    }

    public void ResetAppearance(AndroidX.AppCompat.Widget.Toolbar toolbar, IShellToolbarTracker toolbarTracker)
    {
            
    }
}
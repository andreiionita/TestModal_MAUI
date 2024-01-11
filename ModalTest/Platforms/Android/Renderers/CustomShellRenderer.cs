using Android.Content;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;

namespace ModalTest.Renderers;

public class CustomShellRenderer : ShellRenderer
{
    private readonly Context _context;

    public CustomShellRenderer(Context context) : base(context)
    {
        _context = context;
    }

    protected override IShellTabLayoutAppearanceTracker CreateTabLayoutAppearanceTracker(ShellSection shellSection)
    {
        return new CustomShellTabLayoutAppearanceTracker(this, _context);
    }

    protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
    {
        return new CustomBottomNavAppearance(this, shellItem, _context);
    }

    protected override IShellItemRenderer CreateShellItemRenderer(ShellItem shellItem)
    {
        return new ShellTabItemRenderer(this);
    }

    protected override IShellToolbarAppearanceTracker CreateToolbarAppearanceTracker()
    {
        return new CustomToolbarAppearanceTracker();
    }
}
using Android.Content;
using Android.Widget;
using Google.Android.Material.Tabs;
using Microsoft.Maui.Controls.Platform.Compatibility;

namespace ModalTest.Renderers;

public class CustomShellTabLayoutAppearanceTracker : ShellTabLayoutAppearanceTracker
{
    private readonly Context _context;

    public CustomShellTabLayoutAppearanceTracker(IShellContext shellContext, Context context) : base(shellContext)
    {
        _context = context;
    }

    protected override void SetColors(TabLayout tabLayout, Color foreground, Color background, Color title, Color unselected)
    {
        base.SetColors(tabLayout, foreground, background, title, unselected);

        tabLayout.SetSelectedTabIndicator(null);
        tabLayout.TabRippleColor = null;

        for (var i = 0; i < tabLayout.TabCount; i++)
        {
            var tab = tabLayout.GetTabAt(i);

            if (tab.CustomView != null)
            {
                continue;
            }

            var textView = new TextView(_context, null, 0, Resource.Style.TextAppearance_Material3_TitleMedium)
            {
                Text = tab.Text
            };

            tab.SetCustomView(textView);
        }
    }
}
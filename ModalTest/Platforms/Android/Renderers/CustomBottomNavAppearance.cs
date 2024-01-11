using Android.Content;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform.Compatibility;

namespace ModalTest.Renderers;

public class CustomBottomNavAppearance : ShellBottomNavViewAppearanceTracker
{
    private readonly Context _context;

    public CustomBottomNavAppearance(IShellContext shellContext, ShellItem shellItem, Context context) : base(shellContext, shellItem)
    {
        _context = context;
    }

    public override void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
    {
        base.SetAppearance(bottomView, appearance);

        // add this line with Xamarin.Forms >= 5.0.0 to remove the ripple effect
        bottomView.ItemRippleColor = null;

        var colors = _context.Resources?.GetColorStateList(Resource.Color.m3_tabs_text_color, _context.Theme);
        bottomView.ItemIconTintList = colors;
        bottomView.ItemTextColor = colors;
    }
        
    protected override void SetBackgroundColor(BottomNavigationView bottomView, Color color)
    {
        bottomView.SetBackgroundColor(color.ToAndroid());
    }
}
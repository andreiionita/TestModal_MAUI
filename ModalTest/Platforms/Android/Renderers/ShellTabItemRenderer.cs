using System.ComponentModel;
using Android.OS;
using Android.Views;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.Controls.Platform.Compatibility;
using View = Android.Views.View;

namespace ModalTest.Renderers;

public class ShellTabItemRenderer : ShellItemRenderer
{
    /// <summary>
    /// Defines the _bottomNavigationView.
    /// </summary>
    private BottomNavigationView? _bottomNavigationView;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShellTabItemRenderer"/> class.
    /// </summary>
    /// <param name="shellContext">The shellContext<see cref="IShellContext"/>.</param>
    public ShellTabItemRenderer(IShellContext shellContext) : base(shellContext)
    {
    }

    /// <summary>
    /// View init.
    /// </summary>
    /// <param name="inflater">.</param>
    /// <param name="container">.</param>
    /// <param name="savedInstanceState">.</param>
    /// <returns>.</returns>
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        var outerLayout = base.OnCreateView(inflater, container, savedInstanceState);
        _bottomNavigationView = outerLayout.FindViewById<BottomNavigationView>(Resource.Id.navigationlayout_bottomtabs);

        SetupBadges();

        return outerLayout;
    }

    /// <summary>
    /// The SetupBadges.
    /// </summary>
    private void SetupBadges()
    {
        var visibleItems = ShellItem.Items
                                    .Where(x => x.IsVisible)
                                    .ToList();

        // foreach (var item in visibleItems)
        // {
        //     if (item is null)
        //     {
        //         continue;
        //     }
        //
        //     var index = visibleItems.IndexOf(item);
        //     var text = ShellTabBadge.GetText(item);
        //     var textColor = ShellTabBadge.GetTextColor(item);
        //     var bg = ShellTabBadge.GetBackgroundColor(item);
        //
        //     ApplyBadge(text, bg, index, textColor);
        // }
    }

    /// <summary>
    /// The ApplyBadge.
    /// </summary>
    /// <param name="badgeText">The badgeText<see cref="string"/>.</param>
    /// <param name="badgeBg">The badgeBg<see cref="Color"/>.</param>
    /// <param name="itemId">The itemId<see cref="int"/>.</param>
    /// <param name="textColor">The textColor<see cref="Color"/>.</param>
    private void ApplyBadge(string badgeText,
                            Color badgeBg,
                            int itemId,
                            Color textColor)
    {
        using var bottomNavigationMenuView = (BottomNavigationMenuView?)_bottomNavigationView?.GetChildAt(0);
        var itemView = bottomNavigationMenuView?.FindViewById<BottomNavigationItemView>(itemId);

        if (itemView == null)
        {
            return;
        }

        // if (string.IsNullOrEmpty(badgeText))
        // {
        //     itemView.ApplyBadge(badgeBg, "", textColor);
        // }
        // else
        // {
        //     int.TryParse(badgeText, out var badgeNumber);
        //     itemView.ApplyBadge(badgeBg, badgeNumber != 0 ? badgeText : "", textColor);
        // }
    }

    /// <summary>
    /// Occures when property changes.
    /// </summary>
    /// <param name="sender">.</param>
    /// <param name="e">.</param>
    protected override void OnShellSectionPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        base.OnShellSectionPropertyChanged(sender, e);

        // if (e.PropertyName == ShellTabBadge.TextProperty.PropertyName ||
        //     e.PropertyName == ShellTabBadge.TextColorProperty.PropertyName ||
        //     e.PropertyName == ShellTabBadge.BackgroundColorProperty.PropertyName)
        // {
        //     var item = (ShellSection)sender;
        //
        //     var visibleItems = ShellItem.Items.Where(x => x.IsVisible).ToList();
        //
        //     var index = visibleItems.IndexOf(item);
        //     var text = ShellTabBadge.GetText(item);
        //     var textColor = ShellTabBadge.GetTextColor(item);
        //     var bg = ShellTabBadge.GetBackgroundColor(item);
        //     ApplyBadge(text, bg, index, textColor);
        // }
    }

    protected override void OnTabReselected(ShellSection shellSection)
    {
        base.OnTabReselected(shellSection);

        MainThread.InvokeOnMainThreadAsync(shellSection.Navigation.PopToRootAsync).ConfigureAwait(false);
    }
}
namespace ModalTest.Pages;

public partial class NavigationBarModalExamplePage
{
    public NavigationBarModalExamplePage()
    {
        InitializeComponent();
    }

    private void Button_OnClicked(object sender, EventArgs e)
    {
        Shell.Current.Navigation.PopModalAsync();
    }
}
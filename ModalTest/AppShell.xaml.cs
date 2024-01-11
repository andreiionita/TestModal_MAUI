using ModalTest.Pages;

namespace ModalTest;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        RegisterRoutes();
    }

    private void RegisterRoutes()
    {
        Routing.RegisterRoute("ModalTest.NavigationBarModalExamplePage", typeof(NavigationBarModalExamplePage));
        Routing.RegisterRoute("ModalTest.FirstPage", typeof(FirstPage));
        Routing.RegisterRoute("ModalTest.SecondPage", typeof(SecondPage));
    }
}
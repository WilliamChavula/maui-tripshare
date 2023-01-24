namespace tripshare;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        var page = FreshPageModelResolver.ResolvePageModel<HomePageModel>();
        var basicNavContainer = new FreshNavigationContainer(page);
        MainPage = basicNavContainer;

        // MainPage = new HomePage();
    }
}


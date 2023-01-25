using tripshare.helpers;
namespace tripshare;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        
        FreshPageModelResolver.PageModelMapper =
            new CustomFreshPageModelMapper(typeof(HomePage).Namespace);
        var page = FreshPageModelResolver.ResolvePageModel<HomePageModel>();
        var basicNavContainer = new FreshNavigationContainer(page);
        MainPage = basicNavContainer;
    }
}


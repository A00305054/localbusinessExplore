using localbusinessExplore.Pages;


namespace localbusinessExplore;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        // MainPage = new AppShell();
        // Set the initial MainPage to SplashPage
        MainPage = new SplashScreen();
    }
}

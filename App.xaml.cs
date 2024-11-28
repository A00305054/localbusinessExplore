using localbusinessExplore.Pages;
using Microsoft.Maui.Controls;

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

    // Method to transition from SplashScreen to Shell after splash is done
    public async Task NavigateToMainPageAsync()
    {
        // Create and set AppShell after the splash screen completes
        MainPage = new AppShell();
    }
}

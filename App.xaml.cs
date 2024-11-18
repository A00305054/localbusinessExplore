using localbusinessExplore.Pages;

namespace localbusinessExplore;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();


        MainPage = new SignUpPage();
    }
}

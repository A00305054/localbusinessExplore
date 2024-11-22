using Microsoft.Maui.Controls;

namespace localbusinessExplore.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}
	private void OnLogoutClicked(object sender, EventArgs e)
    {
        // Navigate to LoginPage
        Shell.Current.GoToAsync("//LoginPage");
    }
}

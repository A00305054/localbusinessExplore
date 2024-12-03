using localbusinessExplore.ViewModels;

namespace localbusinessExplore.Pages;

public partial class PlacesPage : ContentPage
{
	public PlacesPage()
	{
		InitializeComponent();
        BindingContext = new PlacesViewModel(); // Initialize ViewModel
    }
}
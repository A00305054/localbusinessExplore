namespace localbusinessExplore.Pages;

public partial class Profile : ContentPage
{
    public Profile()
    {
        InitializeComponent();


    }
    private async void OnEditProfileClicked(object sender, EventArgs e)
    {
        // Navigate to the EditProfile page.
        await Navigation.PushAsync(new EditProfile());
    }
}
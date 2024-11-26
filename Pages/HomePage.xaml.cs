using Microsoft.Maui.Controls;

namespace localbusinessExplore.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void OnProfileClicked(object sender, EventArgs e)
        {
            // Navigate to the Profile Page
            await Navigation.PushAsync(new Profile());
        }

        private void OnLogoutClicked(object sender, EventArgs e)
        {
            // Handle logout logic (to be implemented)
            DisplayAlert("Logout", "You have been logged out.", "OK");
        }
    }
}

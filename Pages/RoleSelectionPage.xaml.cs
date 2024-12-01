using Microsoft.Maui.Controls;

namespace localbusinessExplore.Pages
{
    public partial class RoleSelectionPage : ContentPage
    {
        public RoleSelectionPage()
        {
            InitializeComponent();
        }

        private async void OnUserClicked(object sender, EventArgs e)
        {
            // Navigate to User Login Page
            await Navigation.PushAsync(new LoginPage());
            await NavigateToMainPage();
        }

        private async void OnAdminClicked(object sender, EventArgs e)
        {
            // Navigate to Admin Login Page
            await Navigation.PushAsync(new LoginPage());
            await NavigateToMainPage();
        }

        // Method to transition to the main app page (AppShell)
        private async Task NavigateToMainPage()
        {
            // Navigate to AppShell after the role selection
            if (Application.Current is App app)
            {
                app.MainPage = new AppShell(); // Set AppShell as the main page
            }
        }
    }
}

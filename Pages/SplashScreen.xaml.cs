using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace localbusinessExplore.Pages
{

    public partial class SplashScreen : ContentPage
    {
        public SplashScreen()
        {
            InitializeComponent();
            //NavigateToLoginPage();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Delay for a few seconds to show the splash screen
            await Task.Delay(3000);  // 3 seconds delay

            // Navigate to the main app page (AppShell)
            if (Application.Current is App app)
            {
                await app.NavigateToMainPageAsync();
            }
        }
        private async void NavigateToLoginPage()
        {
            try
            {
                // Wait for 5 seconds to simulate the splash screen delay
                await Task.Delay(5000);

                // Navigate to LoginPage
                Application.Current.MainPage = new LoginPage();
            }
            catch (Exception ex)
            {
                // Handle exceptions (if any)
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}
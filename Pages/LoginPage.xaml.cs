using Microsoft.Maui.Controls;

namespace localbusinessExplore.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        // Login Button Click Event
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string email = emailEntry.Text;  // Updated name
            string password = passwordEntry.Text;  // Updated name

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Please enter both email and password.", "OK");
                return;
            }

            // Mock login validation (replace with actual validation logic)
            if (email == "ankitapatel@gmail.com" && password == "Poonam@91")
            {
                await DisplayAlert("Success", "Login successful!", "OK");

                // Navigate to HomePage (example)
                await Shell.Current.GoToAsync("//HomePage");
            }
            else
            {
                await DisplayAlert("Error", "Invalid credentials. Please try again.", "OK");
            }
        }

        // Sign-Up Button Click Event
        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            // Navigate to SignUpPage
            await Shell.Current.GoToAsync("SignUpPage");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Auth;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using System.Windows.Input;

namespace localbusinessExplore.ViewModels
{
    public class LoginViewModel : BindableObject
    {
        private string _email;
        private string _password;

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
        }

        private async Task Login()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter both email and password.", "OK");
                return;
            }

            try
            {
                // Initialize FirebaseAuthProvider
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyBOw_QvzSH1WqRyX86Bq1d7d7-p8BRTKBA\r\n"));

                // Authenticate with Firebase
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(Email, Password);

                // Retrieve token (optional)
                string idToken = auth.FirebaseToken;

                if (!string.IsNullOrEmpty(idToken))
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "Login successful!", "OK");

                    // Navigate to HomePage
                    await Shell.Current.GoToAsync("//HomePage");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Login failed. Please try again.", "OK");
                }
            }
            catch (FirebaseAuthException ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Login failed: {ex.Reason}", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}

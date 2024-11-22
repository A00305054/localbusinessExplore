using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Firebase.Auth;
using Microsoft.Maui.Controls;

namespace localbusinessExplore.ViewModels
{
    public class SignUpViewModel : BindableObject
    {
        private string _name;
        private string _username;
        private string _email;
        private string _password;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

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

        public ICommand SignUpCommand { get; }

        public SignUpViewModel()
        {
            SignUpCommand = new Command(async () => await SignUp());
        }

        private async Task SignUp()
        {
            if (string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "All fields are required.", "OK");
                return;
            }

            if (Password.Length < 6)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Password must be at least 6 characters.", "OK");
                return;
            }

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyBOw_QvzSH1WqRyX86Bq1d7d7-p8BRTKBA\r\n"));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);

                // User successfully created
                await Application.Current.MainPage.DisplayAlert("Success", "Account created successfully!", "OK");

                // Navigate back to LoginPage
                await Shell.Current.GoToAsync("//LoginPage");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Sign-Up failed: {ex.Message}", "OK");
            }
        }
    }
}

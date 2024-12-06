using localbusinessExplore.Helpers;
using System;

namespace localbusinessExplore.Pages
{
    public partial class EditProfile : ContentPage
    {
        private readonly FirebaseHelper _firebaseHelper;

        public EditProfile()
        {
            InitializeComponent();
            _firebaseHelper = new FirebaseHelper();
        }

        private async void OnSaveChangesClicked(object sender, EventArgs e)
        {
            string name = nameEntry.Text;
            string email = emailEntry.Text;
            string address = addressEntry.Text;
            string age = ageEntry.Text;
            string nationality = nationalityEntry.Text;
            string skills = skillsEditor.Text;

            try
            {
                // Save the profile data to Firebase
                await _firebaseHelper.SaveProfileData(name, email, address, age, nationality, skills);

                // Display a success message
                await DisplayAlert("Success", "Profile updated successfully!", "OK");

                // Navigate to the Profile page
                await Navigation.PushAsync(new Profile());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to save profile: {ex.Message}", "OK");
            }
        }
    }
}

using localbusinessExplore.Helpers;
using System;
using System.Xml;

namespace localbusinessExplore.Pages
{
    public partial class EditProfile : ContentPage
    {
        private readonly FirebaseHelper _firebaseHelper;

        public EditProfile()
        {
            InitializeComponent();
            _firebaseHelper = new FirebaseHelper();
            LoadProfileData();
        }
        private async void LoadProfileData()
        {
            try
            {
                // Fetch the profile data from Firebase
                var profileData = await _firebaseHelper.GetProfileData();

                // Display the fetched data on the page
                nameEntry.Text = profileData?.Name ?? "Name not set";
                emailEntry.Text = profileData?.Email ?? "Email not set";
                addressEntry.Text = profileData?.Address ?? "Address not set";
                ageEntry.Text = profileData?.Age ?? "Age not set";
                nationalityEntry.Text = profileData?.Nationality ?? "Nationality not set";
                skillsEditor.Text = profileData?.Skills ?? "Skills not set";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load profile data: {ex.Message}", "OK");
            }
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

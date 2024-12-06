using localbusinessExplore.Helpers;
using System;

namespace localbusinessExplore.Pages
{
    public partial class Profile : ContentPage
    {
        private readonly FirebaseHelper _firebaseHelper;

        public Profile()
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
                nameLabel.Text = profileData?.Name ?? "Name not set";
                emailLabel.Text = profileData?.Email ?? "Email not set";
                addressLabel.Text = profileData?.Address ?? "Address not set";
                ageLabel.Text = profileData?.Age ?? "Age not set";
                nationalityLabel.Text = profileData?.Nationality ?? "Nationality not set";
                skillsLabel.Text = profileData?.Skills ?? "Skills not set";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load profile data: {ex.Message}", "OK");
            }
        }

        private async void OnEditProfileClicked(object sender, EventArgs e)
        {
            // Navigate to the EditProfile page
            await Navigation.PushAsync(new EditProfile());
        }
    }
}

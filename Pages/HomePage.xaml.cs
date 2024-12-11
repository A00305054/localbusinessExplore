using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using localbusinessExplore.Entities;
using localbusinessExplore.ViewModels;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors;
using Location = Microsoft.Maui.Devices.Sensors.Location;
using System.Diagnostics;


namespace localbusinessExplore.Pages
{
    public partial class HomePage : ContentPage
    {
        private const string GooglePlacesApiKey = "AIzaSyCtY98KNBJYOX4AUmRX9NxXhj_nsQ_wp8k";
        private const string GooglePlacesApiUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json";

        public HomePage()
        {
            InitializeComponent();
            //LoadSudburyLocation();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadSudburyLocation(); // Call the method when the page appears
        }

        private void LoadSudburyLocation()
        {
            // Coordinates for Greater Sudbury, Ontario
            var sudburyCoordinates = new Location(46.52249923144501, -80.94380543893604);
            var mapSpan = MapSpan.FromCenterAndRadius(sudburyCoordinates, Distance.FromKilometers(1));  // Set the zoom level

            // Move the map to Greater Sudbury location
            MapControl.MoveToRegion(mapSpan);

            // Optionally, add a pin at the center of the city
            var sudburyPin = new Pin
            {
                Label = "New Sudbury Center, Ontario",
                Address = "Sudbury, ON, Canada",
                Type = PinType.Place,
                Location = sudburyCoordinates
            };

            // Add the pin to the map
            MapControl.Pins.Add(sudburyPin);
        }

        private async void OnShowAllTapped(object sender, EventArgs e)
        {
            // Navigate to the MapPage
            //await Navigation.PushAsync(new MapPage());
        }

        private async void OnExploreClicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new PlacesPage());

                //// Get the user's current location (Hardcoded for Sudbury, ON)
                //double latitude = 46.490001;
                //double longitude = -81.010002;

                //// Construct the URL for the API call
                //string url = $"{GooglePlacesApiUrl}?location={latitude},{longitude}&radius=1500&type=business&key={GooglePlacesApiKey}";

                //using var httpClient = new HttpClient();
                //var response = await httpClient.GetFromJsonAsync<GooglePlaces>(url);

                //// Access the 'results' property, not 'result'
                //if (response?.results != null && response.results.Any())
                //{
                //    var places = response.results;
                //    var placeList = new List<Place>();

                //    // Extract business details
                //    foreach (var place in places)
                //    {
                //        var business = new Place
                //        {
                //            Name = place.name,
                //            Address = place.vicinity, // Address or vicinity of the place
                //            PhoneNumber = "N/A", // Phone number (not provided in API structure here)
                //            Rating = place.rating?.ToString() ?? "N/A", // Rating (if available)
                //            OpeningHours = place.opening_hours?.weekday_text != null
                //                ? string.Join(", ", place.opening_hours.weekday_text)
                //                : "N/A", // Opening hours (if available)
                //            BusinessStatus = place.business_status ?? "N/A", // Business status (if available)
                //            Location = place.geometry?.location != null
                //                ? $"{place.geometry.location.lat}, {place.geometry.location.lng}"
                //                : "N/A", // Location (latitude, longitude)
                //            Photos = place.photos?.Select(p => p.photo_reference).ToList() ?? new List<string>(), // Photos (if available)
                //        };
                //        placeList.Add(business);
                //    }

                //    // Create a new PlacesPage and pass the data
                //    var placesPage = new PlacesPage();
                //    placesPage.BindingContext = new PlacesViewModel { Places = new ObservableCollection<Place>(placeList) };

                //    // Navigate to the new page
                //    await Navigation.PushAsync(placesPage);
                //}
                //else
                //{
                //    await DisplayAlert("Error", "No businesses found nearby.", "OK");
                //}
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }


        private async void OnProfileClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile());
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            bool shouldLogout = await Shell.Current.DisplayAlert("Logout", "Are you sure you want to log out?", "Yes", "No");

            if (shouldLogout)
            {
                // Navigate to the LoginPage
                await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
            }
            else
            {
                // Stay on the HomePage (do nothing)
            }
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            // Navigate to the MapPage
            await Navigation.PushAsync(new MapPage());
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            bool shouldLogout = await Shell.Current.DisplayAlert("Logout", "Are you sure you want to log out?", "Yes", "No");

            if (shouldLogout)
            {
                // Navigate to the LoginPage
                await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
            }
            else
            {
                // Stay on the HomePage (do nothing)
            }
        }

        private async void OnCardTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FoodCategory());
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new GroceryCategory());
        }
    }
}

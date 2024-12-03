using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace localbusinessExplore.Pages
{

    public class GooglePlaces
    {
        public class Geometry
        {
            public Location location { get; set; }
            public Viewport viewport { get; set; }
        }

        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Northeast
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Photo
        {
            public int height { get; set; }
            public List<string> html_attributions { get; set; }
            public string photo_reference { get; set; }
            public int width { get; set; }
        }

        public class PlusCode
        {
            public string compound_code { get; set; }
            public string global_code { get; set; }
        }

        public class Result
        {
            public Geometry geometry { get; set; }
            public string icon { get; set; }
            public string icon_background_color { get; set; }
            public string icon_mask_base_uri { get; set; }
            public string name { get; set; }
            public List<Photo> photos { get; set; }
            public string place_id { get; set; }
            public string reference { get; set; }
            public string scope { get; set; }
            public List<string> types { get; set; }
            public string vicinity { get; set; }
            public string business_status { get; set; }
            public PlusCode plus_code { get; set; }
        }

        public class Root
        {
            public List<object> html_attributions { get; set; }
            public List<Result> results { get; set; }
            public string status { get; set; }
        }

        public class Southwest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Viewport
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }


    }

    public partial class HomePage : ContentPage
    {

        //https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=46.490001,-81.010002&radius=1500&type=business&key=AIzaSyCtY98KNBJYOX4AUmRX9NxXhj_nsQ_wp8k


        private const string GooglePlacesApiKey = "AIzaSyCtY98KNBJYOX4AUmRX9NxXhj_nsQ_wp8k";
        private const string GooglePlacesApiUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json";

        public HomePage()
        {
            InitializeComponent();
        }

        private async void OnExploreClicked(object sender, EventArgs e)
        {
            try
            {
                // Get the user's current location
                double latitude = 46.490001; // Sudbury, ON, Canada
                double longitude = -81.010002;

                //  correct API key variable
                string url = $"{GooglePlacesApiUrl}?location={latitude},{longitude}&radius=1500&type=business&key={GooglePlacesApiKey}";

                using var httpClient = new HttpClient();
                var response = await httpClient.GetFromJsonAsync<GooglePlaces.Root>(url);

                if (response?.results != null && response.results.Any())
                {

                    var places = response.results;

                    string message = "";

                    // Extract business names
                    foreach (var place in places)
                    {
                        message += "," + place.name;
                    }
                    await DisplayAlert("Places", message, "OK");

                }
                else
                {
                    await DisplayAlert("Error", "No businesses found nearby.", "OK");
                }
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

        private void OnLogoutClicked(object sender, EventArgs e)
        {
            DisplayAlert("Logout", "You have been logged out.", "OK");
        }
    }

}

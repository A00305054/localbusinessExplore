using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System;
using System.Threading.Tasks;

namespace localbusinessExplore.Pages
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent(); // Ensure this is called to initialize the page's components
            LoadSudburyLocation(); // Set the initial map location to Sudbury, Ontario
        }

        // Method to load Greater Sudbury's location
        private void LoadSudburyLocation()
        {
            // Coordinates for Greater Sudbury, Ontario
            var sudburyCoordinates = new Location(46.52249923144501, -80.94380543893604);
            var mapSpan = new MapSpan(sudburyCoordinates, 0.03, 0.03);  // Set the zoom level

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
    }
}



/*using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System;
using System.Threading.Tasks;

namespace localbusinessExplore.Pages
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();  // Ensure this is called to initialize the page's components
            StartLocationUpdates(); // Start location updates
        }

        // Start receiving location updates
        private async void StartLocationUpdates()
        {
            try
            {
                // Continuously request the location at regular intervals
                while (true)
                {
                    var location = await GetUserLocationAsync();

                    if (location != null)
                    {
                        // Update the map to show the new location
                        var userPosition = new Location(location.Latitude, location.Longitude);
                        var mapSpan = new MapSpan(userPosition, 0.05, 0.05); // Use appropriate zoom levels
                        MapControl.MoveToRegion(mapSpan);  // Correctly reference MapControl

                        // Optionally, add a pin at the user's location
                        var userPin = new Pin
                        {
                            Label = "You are here",           // Correct Label for the Pin
                            Address = "Current Location",     // Correct Address for the Pin
                            Type = PinType.Place,             // Type of Pin
                            Location = userPosition          // Correct Location property
                        };

                        // Ensure we don't add the same pin multiple times
                        if (MapControl.Pins.Count == 0)
                        {
                            MapControl.Pins.Add(userPin); // Add pin to the map
                        }
                    }

                    await Task.Delay(5000); // Delay to request location every 5 seconds (adjust as needed)
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred while tracking location: {ex.Message}", "OK");
            }
        }

        // Method to get the user's location
        private async Task<Location> GetUserLocationAsync()
        {
            try
            {
                // Try to get the last known location first
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    // If no last known location, request the current location
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }

                return location;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Unable to retrieve location: {ex.Message}", "OK");
                return null;
            }
        }
    }
}
*/
using Firebase.Database;
using localbusinessExplore.Entities;
using System.Collections.ObjectModel;

namespace localbusinessExplore.Pages;

public partial class EventsCategory : ContentPage
{
    public ObservableCollection<Place> Businesses { get; set; } = new ObservableCollection<Place>();

    public EventsCategory()
	{
		InitializeComponent();
        BindingContext = this;
        FetchBusinesses();
    }

    private async void FetchBusinesses()
    {
        try
        {
            // Initialize Firebase client
            var firebase = new FirebaseClient("https://local-business-explorer-default-rtdb.firebaseio.com/");

            // Fetch all businesses from Firebase
            var items = await firebase
                .Child("Businesses")
                .OnceAsync<Place>();

            // Log fetched data for debugging
            Console.WriteLine($"Fetched {items.Count} businesses from Firebase.");

            // Filter businesses locally based on category "Food"
            var foodBusinesses = items.Where(item => item.Object.Category == "Events").ToList();

            // Process the filtered data and add it to the ObservableCollection
            foreach (var item in foodBusinesses)
            {
                try
                {
                    // Access the Place object within the FirebaseObject
                    var place = item.Object;

                    // Add business data to the ObservableCollection
                    Businesses.Add(new Place
                    {
                        Name = place.Name ?? "No Name", // Fallback in case Name is missing
                        Address = place.Address ?? "No Address",
                        ContactNo = place.ContactNo ?? "No Contact",
                        Rating = place.Rating, // Default value if Rating is missing
                        OpeningHours = place.OpeningHours ?? "No Hours",
                        Photo = place.Photo ?? "https://via.placeholder.com/150", // Default placeholder
                        Category = place.Category ?? "Unknown" // Default Category
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing item: {item.Key} - {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Firebase fetch error: {ex.Message}");
            // Log stack trace for more details
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");

            // Optionally, log inner exceptions if any
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
            }
        }
    }
}
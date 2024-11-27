using localbusinessExplore.Entities;
using localbusinessExplore.Services;
using localbusinessExplore.ViewModels;


namespace localbusinessExplore.Pages;

public partial class EventsPage : ContentPage
{
    private readonly EventsPageViewModel _viewmodel;
    private readonly FirebaseDb _firebaseDb;
    private readonly EventDataService _eventDataService;
    public EventsPage(EventsPageViewModel viewModel, FirebaseDb firebaseDb, EventDataService eventDataService)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewmodel = viewModel;
        _firebaseDb = firebaseDb;
        _eventDataService = eventDataService;
    }
    private async void OnTitleTapped(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync($"///{nameof(HomePage)}");
    }
    public async void OnFetchEventsAsyncClicked(object sender, EventArgs e)
    {

        var events = await _firebaseDb.EventResults();
        _eventDataService.EventList = events;


        await Shell.Current.GoToAsync($"///{nameof(EventsPage)}");




    }
    // Event handler for the Home button click
    private async void OnHomeButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"///{nameof(HomePage)}");


    }

    // Event handler for the Fetch Events button click

    // Event handler for the Logout button click
    private async void OnLogoutButtonClicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Logout", "Do you really want to log out?", "Yes", "No");
        if (answer)
        {
            await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
        }
    }

}
using CommunityToolkit.Mvvm.ComponentModel;
using localbusinessExplore.Entities;
using System.Collections.ObjectModel;


namespace localbusinessExplore.ViewModels
{

    public class EventsPageViewModel : ObservableObject
    {
        private readonly EventDataService _eventDataService;

        public ObservableCollection<EventResult> Events { get; set; }

        public EventsPageViewModel(EventDataService eventDataService)
        {
            _eventDataService = eventDataService;
            Events = new ObservableCollection<EventResult>(_eventDataService.EventList);
        }
    }

}

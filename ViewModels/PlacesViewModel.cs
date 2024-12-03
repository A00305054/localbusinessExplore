using System.Collections.ObjectModel;
using localbusinessExplore.Entities;  // Adjust this if necessary

namespace localbusinessExplore.ViewModels
{
    public class PlacesViewModel
    {
        public ObservableCollection<Place> Places { get; set; }

        public PlacesViewModel()
        {
            Places = new ObservableCollection<Place>();
        }
    }
}

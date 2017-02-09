using GamesLibrary.DataStore.Mocks;
using GamesLibrary.DataStore.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GamesLibrary.Client.Core.ViewModel
{
    public class WatchlistViewModel : BaseViewModel
    {
        public WatchlistViewModel(INavigation navigation) : base(navigation) { }

        private ObservableCollection<IGrouping<QuarterDate, Game>> _groupedWatchlist;

        public ObservableCollection<IGrouping<QuarterDate, Game>> GroupedWatchlist
        {
            get { return _groupedWatchlist; }
            set { SetProperty(ref _groupedWatchlist, value); }
        }

        //TODO: Build infrastructure for async loading
        public async Task LoadAsync()
        {
            //TODO: !!!inject via DI the datastore. This is in the IoC-Pattern NOT allowed!!!
            var store = new UserDataStore();

            var list = await store.GetWatchlistAsync(null);

            var orderedWatchlist = from item in list
                                   orderby item.ReleaseDate
                                   select new { Quarter = new QuarterDate(item.ReleaseDate), Game = item };

            GroupedWatchlist = new ObservableCollection<IGrouping<QuarterDate, Game>>(from item in orderedWatchlist
                                                                                      group item.Game by item.Quarter into g
                                                                                      select g);
        }
    }
}

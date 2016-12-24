using FormsToolkit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GameLibrary.Client.Core.ViewModel
{
    public class MainNavigationViewModel: BaseViewModel
    {
        public MainNavigationViewModel(INavigation navigation) : base(navigation)
        {
            var masterPageItems = new List<NavigationMenuItem>();
            masterPageItems.Add(new NavigationMenuItem
            {
                Title = "Last searched",
                IconSource = "\uE8EF;",
                IconGlyphText = "\uE773",
                TargetViewModelType = typeof(GameArchiveViewModel)
            });
            masterPageItems.Add(new NavigationMenuItem
            {
                Title = "Watchlist",
                IconSource = "asdasd",
                IconGlyphText = "\uE728",
                TargetViewModelType = typeof(WatchlistViewModel)
            });
            masterPageItems.Add(new NavigationMenuItem
            {
                Title = "Archive",
                IconSource = "asdasd",
                IconGlyphText = "\uE82D",
                TargetViewModelType = typeof(GameArchiveViewModel)
            });
            masterPageItems.Add(new NavigationMenuItem
            {
                Title = "Next Releases",
                IconSource = "asdasd",
                IconGlyphText = "\uEE93",
                TargetViewModelType = typeof(NavigationMenuItem)
            });

            NavigationMenuItems = new ObservableCollection<NavigationMenuItem>(masterPageItems);

            var settingsMenu=new List<NavigationMenuItem>() { new NavigationMenuItem() { Title = "Settings",
                IconGlyphText = "\uE115",
                TargetViewModelType = typeof(GameArchiveViewModel) } };

            NavigationSettingsMenuItems = new ObservableCollection<NavigationMenuItem>(settingsMenu);
        }

        private ObservableCollection<NavigationMenuItem> _navigationMenuItems;

        public ObservableCollection<NavigationMenuItem> NavigationMenuItems
        {
            get { return _navigationMenuItems; }
            set { SetProperty(ref _navigationMenuItems, value); }
        }

        private ObservableCollection<NavigationMenuItem> _navigationSettingsMenuItems;

        public ObservableCollection<NavigationMenuItem> NavigationSettingsMenuItems
        {
            get { return _navigationSettingsMenuItems; }
            set { SetProperty(ref _navigationSettingsMenuItems, value); }
        }

        private string _textSearchInput;

        public string TextSearchInput
        {
            get { return _textSearchInput; }
            set { SetProperty(ref _textSearchInput, value); }
        }


        ICommand _searchGamesCommand;
        public ICommand SearchGamesCommand =>
            _searchGamesCommand ?? (_searchGamesCommand = new Command(async () => await SearchGamesAsync()));

        private Task SearchGamesAsync()
        {
            MessagingService.Current.SendMessage<MessagingServiceAlert>(MessageKeys.Message,
                new MessagingServiceAlert
                {
                    Title = "Suche",
                    Message = TextSearchInput,
                    Cancel = "OK"
                });

            return Task.FromResult(false);
        }
    }
}

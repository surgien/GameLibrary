using GamesLibrary.Client.Core.ViewModel;
using GamesLibrary.Client.UI.Pages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GamesLibrary.Client.UI
{
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<Type, Page> pages;

        public MainPage()
        {
            pages = new Dictionary<Type, Page>();
            InitializeComponent();

            masterPage.ListView.ItemSelected += OnItemSelected;
            masterPage.SettingsListView.ItemSelected += OnItemSelected;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as NavigationMenuItem;
            if (item != null)
            {
                NavigateCore(item.TargetViewModelType);
            }
        }

        /// <summary>
        /// Public Navigation
        /// </summary>
        /// <param name="viewModelType"></param>
        public void Navigate(Type viewModelType)
        {
            var vm = (MainNavigationViewModel)masterPage.BindingContext;
            var page = vm.NavigationMenuItems.Where(item => item.TargetViewModelType.Equals(viewModelType)).Single();

            masterPage.ListView.SelectedItem = page;
        }

        /// <summary>
        /// Private navigationlogic for UI-Sync and Page creation
        /// </summary>
        /// <param name="viewModelType"></param>
        private void NavigateCore(Type viewModelType)
        {
            if (!pages.ContainsKey(viewModelType))
            {
                //only cache specific pages
                if (viewModelType.Equals(typeof(GameArchiveViewModel)))
                {
                    pages.Add(viewModelType, new GameArchivePage());
                }
                else if (viewModelType.Equals(typeof(WatchlistViewModel)))
                {
                    pages.Add(viewModelType, new WatchlistPage());
                }
            }
            var page = pages[viewModelType];
            Detail = new NavigationPage(page);
            masterPage.ListView.SelectedItem = null;
            masterPage.SettingsListView.SelectedItem = null;

            if (Device.Idiom == TargetIdiom.Phone)
            {
                IsPresented = false;
                Detail.ToolbarItems.Add(new ToolbarItem() { Priority = 10, Name = "Search", Command = new Command(() => IsPresented = true) });
            }

            Detail.ToolbarItems.Add(new ToolbarItem() { Priority = 10, Name = "TEST", Command = new Command(() => Navigate(typeof(WatchlistViewModel))) });
        }
    }
}

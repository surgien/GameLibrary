using GamesLibrary.Client.Core;
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
                NavigateCore(item.TargetViewModelType, item.Title);
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

            if (Device.OS == TargetPlatform.Android)
            {
                //no radiobuttons or persistent selecteditems in menu for android
                NavigateCore(viewModelType, page.Title);
            }
            else
            {
                masterPage.ListView.SelectedItem = page;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            masterPage.ListView.SelectedItem = null;
            masterPage.SettingsListView.SelectedItem = null;
        }

        /// <summary>
        /// Private navigationlogic for UI-Sync, Page creation and View-ViewModel-Mappings
        /// </summary>
        /// <param name="viewModelType"></param>
        private void NavigateCore(Type viewModelType, string title)
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
            var detailPage = new NavigationPage(page);
            masterPage.ListView.SelectedItem = null;
            masterPage.SettingsListView.SelectedItem = null;

            if (Device.Idiom == TargetIdiom.Phone)
            {
                IsPresented = false;
                detailPage.ToolbarItems.Add(new ToolbarItem() { Priority = 10, Name = "Search", Command = new Command(() => IsPresented = true) });
            }

            if (Settings.CurrentTheme == ApplicationTheme.Dark)
            {
                detailPage.BarBackgroundColor = Color.FromHex("171717");
            }

            if (Device.OS == TargetPlatform.Windows)
            {
                page.Padding = new Thickness(10, 10);
            }

            page.Title = title;
            Detail = detailPage;
        }
    }
}

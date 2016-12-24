using GameLibrary.Client.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GameLibrary.Client.UI
{
    public partial class NavigationMenuPage : ContentPage
    {
        public ListView ListView { get { return NavigationListView; } }
        public ListView SettingsListView { get { return NavigationSettingsListView; } }
        private MainNavigationViewModel vm;

        public NavigationMenuPage()
        {
            InitializeComponent();

            BindingContext = vm = new MainNavigationViewModel(Navigation);
        }
    }
}

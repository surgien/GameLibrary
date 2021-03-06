﻿using GamesLibrary.Client.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GamesLibrary.Client.UI.Pages
{
    public partial class WatchlistPage : ContentPage
    {
        private WatchlistViewModel vm;

        public WatchlistPage()
        {
            InitializeComponent();

            BindingContext = vm = new WatchlistViewModel(Navigation);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await vm.LoadAsync();
        }
    }
}

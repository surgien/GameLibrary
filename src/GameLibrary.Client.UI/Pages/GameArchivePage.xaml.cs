using GameLibrary.Client.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GameLibrary.Client.UI.Pages
{
    public partial class GameArchivePage : ContentPage
    {
        private GameArchiveViewModel vm;

        public GameArchivePage()
        {
            InitializeComponent();

            BindingContext = vm = new GameArchiveViewModel(Navigation);
        }
    }
}

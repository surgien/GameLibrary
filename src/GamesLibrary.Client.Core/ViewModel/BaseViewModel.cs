using MvvmHelpers;
using Xamarin.Forms;

namespace GamesLibrary.Client.Core.ViewModel
{
    public class BaseViewModel : ObservableObject
    {
        protected INavigation Navigation { get; }

        public BaseViewModel(INavigation navigation = null)
        {
            Navigation = navigation;
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
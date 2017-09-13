using GamesLibrary.DataStore.Model;
using Xamarin.Forms;
using System;

namespace GamesLibrary.Client.Core.ViewModel
{
    public class GameArchiveViewModel : BaseViewModel
    {
        public GameArchiveViewModel(INavigation navigation) : base(navigation)
        {
            FollowGameCommand = new ActionCommand(FollowGame, "\uE8D9", "Follow");
        }

        public ActionCommand FollowGameCommand { get; }

        private void FollowGame()
        {
            FollowGameCommand.Icon = "\uE735";
            FollowGameCommand.Title = "Unfollow";
            FollowGameCommand.IsEnabled = false;
        }
    }
}

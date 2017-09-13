using System;
using System.Collections.ObjectModel;

namespace GamesLibrary.DataStore.Model
{
    public class Game : ObservableObject
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private DateTime _releaseDate;

        public DateTime ReleaseDate
        {
            get { return _releaseDate; }
            set { SetProperty(ref _releaseDate, value); }
        }

        private string _developer;

        public string Developer
        {
            get { return _developer; }
            set { SetProperty(ref _developer, value); }
        }

        private GameGenre _genre;

        public GameGenre Genre
        {
            get { return _genre; }
            set { SetProperty(ref _genre, value); }
        }

        private ObservableCollection<string> _tags;

        public ObservableCollection<string> Tags
        {
            get { return _tags; }
            set { SetProperty(ref _tags, value); }
        }

        //TODO: not final!!!
        public string ImageUri { get; set; } = "https://images.igdb.com/igdb/image/upload/t_cover_big/th6f7cexuwhjrzdw18rq.jpg";
    }
}

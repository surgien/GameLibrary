namespace GamesLibrary.DataStore.Model
{
    public class GameGenre : ObservableObject
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }
}
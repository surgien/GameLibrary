using GamesLibrary.DataStore.Definitions;
using GamesLibrary.DataStore.Mocks;
using GamesLibrary.DataStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesLibrary.DataStore.Mocks
{
    public class UserDataStore : IUserDataStore
    {
        public Task<IEnumerable<Game>> GetGameArchiveAsync(string userID)
        {
            var games = new List<Game>();
            var genres = new List<GameGenre>();
            genres.Add(new GameGenre() { Name = "RTS" });

            games.Add(new Game() { Title = "Warhammer 40,000: Dawn of War III", Developer = "Relic Entertainment ", ReleaseDate = new DateTime(2012, 12, 12) });
            games.Add(new Game() { Title = "Warhammer 40,000: Dawn of War III", Developer = "Relic Entertainment ", ReleaseDate = DateTime.Today });
            games.Add(new Game() { Title = "Warhammer 40,000: Dawn of War III", Developer = "Relic Entertainment ", ReleaseDate = DateTime.Today });
            games.Add(new Game() { Title = "Warhammer 40,000: Dawn of War III", Developer = "Relic Entertainment ", ReleaseDate = DateTime.Today.AddYears(-2) });
            games.Add(new Game() { Title = "Warhammer 40,000: Dawn of War III", Developer = "Relic Entertainment ", ReleaseDate = DateTime.Today.AddYears(-2) });

            return Task.FromResult(games.AsEnumerable());
        }

        public Task<IEnumerable<Game>> GetWatchlistAsync(string userID)
        {
            var games = new List<Game>();
            var genres = new List<GameGenre>();
            genres.Add(new GameGenre() { Name = "RTS" });

            games.Add(new Game() { Title = "Warhammer 40,000: Dawn of War III", Developer = "Relic Entertainment ", ReleaseDate = new DateTime(2012, 12, 12) });
            games.Add(new Game() { Title = "Warhammer 40,000: Dawn of War III", Developer = "Relic Entertainment ", ReleaseDate = DateTime.Today });
            games.Add(new Game() { Title = "Warhammer 40,000: Dawn of War III", Developer = "Relic Entertainment ", ReleaseDate = DateTime.Today });
            games.Add(new Game() { Title = "Warhammer 40,000: Dawn of War III", Developer = "Relic Entertainment ", ReleaseDate = DateTime.Today.AddYears(-2) });
            games.Add(new Game() { Title = "Warhammer 40,000: Dawn of War III", Developer = "Relic Entertainment ", ReleaseDate = DateTime.Today.AddYears(-2) });
            games.Add(new Game() { Title = "Warhammer 40,000: Dawn of War III", Developer = "Relic Entertainment ", ReleaseDate = DateTime.Today });
            games.Add(new Game() { Title = "Warhammer 40,000: Dawn of War III", Developer = "Relic Entertainment ", ReleaseDate = DateTime.Today.AddMonths(4) });
            games.Add(new Game() { Title = "Warhammer 40,000: Dawn of War III", Developer = "Relic Entertainment ", ReleaseDate = DateTime.Today.AddMonths(4) });
            games.Add(new Game() { Title = "Warhammer 40,000: Dawn of War III", Developer = "Relic Entertainment ", ReleaseDate = DateTime.Today.AddMonths(-4) });

            return Task.FromResult(games.AsEnumerable());
        }
    }
}

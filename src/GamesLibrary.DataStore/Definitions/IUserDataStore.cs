using GamesLibrary.DataStore.Definitions;
using GamesLibrary.DataStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesLibrary.DataStore.Definitions
{
    public interface IUserDataStore
    {
        Task<IEnumerable<Game>> GetGameArchiveAsync(string userID);

        Task<IEnumerable<Game>> GetWatchlistAsync(string userID);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamLauncher.Core.Service
{
    public class ListLock
    {
        List<String> _games = new List<String>();

        public ListLock() { }

        public void addAllGamePaths(List<String> games)
        {
            lock (_games)
            {
                _games.AddRange(games);
            }

        }

        public List<String> getGamePaths()
        {
            return _games;
        }
    }
}

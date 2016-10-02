using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamLauncher.Core.Service
{
   public interface IGameService
    {
        Game lookUpGameByName(String name);

        ISet<Game> lookUpAllGamesOnAllDrives();


        
    }
}

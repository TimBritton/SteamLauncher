using SteamLauncher.Core.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamLauncher.Core
{
   public class SteamGameLauncher
   {
        SteamGameService gameService = new SteamGameService();
        public static void launchGameById(String id)
        {
            //TODO: should I try to check to see if the id exists?
            //hook into steams backend run process.
            Process.Start("steam://rungameid/" + id);

        }

        public static void launchGameByName(String name)
        {
            //TODO look up id from the game service.
        }

   }
}

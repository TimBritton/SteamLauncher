using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SteamLauncher.Core
{
  
    public class LauncherConfig
    {

        string _steamDirectory;

       
        public string SteamDirectory
        {
            get { return _steamDirectory; }
            set { _steamDirectory = value; }
        }

       Game[] _games;

    
        public Game[] Games
        {
            get { return _games; }
            set { _games = value; }
        }

       public LauncherConfig() { }

        public LauncherConfig(string directory, List<Game> games)
        {
            _steamDirectory = directory;
            _games = games.ToArray<Game>() ;
        
        }

      
    }
}

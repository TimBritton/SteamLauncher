using SteamLauncher.Core;
using SteamLauncher.Core.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SteamLauncherBackend
{
    class Program
    {
        
        public static void Main(string[] args)
        {

           for(int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-export":
                        Export();
                        break;

                    case "-start":
                        if (i + 1 < args.Length)
                        {
                            ExecuteGame(args[i + 1].Trim());
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Please provide the required arguments");
                        }
                    break;

                    default:
                        Console.WriteLine("Argument Not found");
                        break;
                }
            }
          

        }

        public static void ExecuteGame(String id)
        {
            SteamGameLauncher.launchGameById(id);
        }

        public static void Export()
        {
            SteamGameService gameService = new SteamGameService();
            var games = gameService.lookUpAllGamesOnAllDrives();
            GamesJson gj = new GamesJson(games.ToList<Game>());
            FileStream fs = new FileStream("./games.json", FileMode.OpenOrCreate);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(GamesJson));
            ser.WriteObject(fs, gj);
        }
    }

    [DataContract]
    class GamesJson
    {
        public GamesJson(List<Game> gs)
        {
            games = gs;
        }

        [DataMember]
        List<Game> games;

    }
}

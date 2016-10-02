using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SteamLauncher.Core.Service
{
    class ThreadedDirectoryProcessor
    {
        public static void processDrive(DirectoryInfo di, ref ListLock l)
        {
            l.addAllGamePaths(WalkDirectoryTree(di));
        }

        static List<String> WalkDirectoryTree(System.IO.DirectoryInfo root)
        {
            System.IO.DirectoryInfo[] subDirs = null;
            List<String> steamApps = new List<String>();

            

            if (root.Name.ToLower() == "windows" || root.Name.ToLower() == "$recycle.bin")
            {
                return new List<string>();
            }

            if (((root.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden) && root.Name.Length > 3)
            {
                Console.WriteLine(root.FullName + " Status:" + ((root.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden));
                return new List<string>();
            }

            if (root.Name.ToLower().Contains("steamapps"))
            {
                steamApps.Add(root.FullName);
            }

            // Now find all the subdirectories under this directory.
            try
            {
                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory.
                    steamApps.AddRange(WalkDirectoryTree(dirInfo));
                }
            }
            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine("Could Not Access" + root.FullName);
            }
            catch (PathTooLongException p)
            {
                Console.WriteLine("Path Name too long");
            }
            return steamApps;
        }
    }


    public class SteamGameService : IGameService
    {
        public SteamGameService()
        { }

        public ISet<Game> lookUpAllGamesOnAllDrives()
        {
            ListLock l = new ListLock();
            List<Thread> threads = new List<Thread>();
            foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => x.IsReady == true))
            {
                threads.Add(new Thread(() => ThreadedDirectoryProcessor.processDrive(d.RootDirectory, ref l)));             
            }

            foreach (Thread t in threads)
            {
                t.Start();
            }


            while (threads.Any(t => t.ThreadState != ThreadState.Stopped))
            {

            }

            HashSet<Game> games = new HashSet<Game>();
            foreach (String path in l.getGamePaths())
            {
                foreach(Game g in parseGameFiles(path))
                {
                    games.Add(g);
                }
            }

            return games;
        }

        


        public Game lookUpGameByName(string name)
        {
            foreach (Game g in lookUpAllGamesOnAllDrives().Where<Game>(x => x.Name == name))
            {
                return g;
            }

            return null;
        }

        private ISet<Game> parseGameFiles(String path)
        {
            HashSet<Game> games = new HashSet<Game>();
            string[] files = null;
            try
            {
                files = System.IO.Directory.GetFiles(path, "*.acf");
            }
            catch (DirectoryNotFoundException dne)
            {
                return new HashSet<Game>();
            }

            if (files == null)
            {
                return new HashSet<Game>();
            }
            foreach (string a in files)//Import game information
            {

                StreamReader reader = File.OpenText(a);
                string fileText = reader.ReadToEnd();

                string[] lines = fileText.Split('\n');
                string name = "";
                int id = 0;
                foreach (var line in lines)
                {
                    if (Regex.IsMatch(line, "\"name\""))
                    {
                        String[] strs = line.Split('\"');
                        foreach (String str in strs)
                        {
                            if (str.Trim().Length > 1)
                            {
                                if (!Regex.IsMatch(str.Trim(), "name"))
                                {
                                    name = str.Trim();
                                }
                            }
                        }
                    }
                    else if (Regex.IsMatch(line, "appID"))
                    {
                        String[] strs = line.Split('\"');
                        foreach (String str in strs)
                        {
                            if (str.Trim().Length > 1)
                            {
                                if (!Regex.IsMatch(str.Trim(), "appID"))
                                {
                                    Int32.TryParse(str.Trim(), out id);
                                }
                            }
                        }

                    }
                }
                if (name != "")
                {
                    games.Add(new Game(name, id));
                }

            }//end foreach game information

            return games;
        }
    }
}

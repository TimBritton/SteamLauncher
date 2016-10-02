using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using SteamLauncher.Core;
using System.Text.RegularExpressions;

namespace SteamLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Game> games = new List<Game>();
        LauncherConfig config;
        string path;
        public MainWindow(string _path)
        {
            InitializeComponent();
            string[] files = { "", "", "" };
            path = _path;
            path = "F:\\SteamLibrary\\SteamApps";
            try
            {
              files = System.IO.Directory.GetFiles(path, "*.acf");
            }
            catch(DirectoryNotFoundException dne)
            {

                
            }
            foreach (string a in files)//Import game information
            {
                
                StreamReader reader = File.OpenText(a);
                string fileText =reader.ReadToEnd();

                string[] lines = fileText.Split('\n');
                string name = "";
                int id = 0;
                foreach(var line in lines)
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

            games.Sort();
			//for(int i = 0; i < 4; i++)
            foreach (Game a in games)
            {
                GameButton dynamicb = new GameButton(a);
              
                buttonHolder.Children.Add(dynamicb);
                dynamicb.Click += GButton_ClicK;
            }
			
		
        }

        private void GButton_ClicK(object sender, RoutedEventArgs e)
        {
            GameButton a = (GameButton)sender;

            a.Game.run();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            config = new LauncherConfig(path, games);
            ConfigurationHelper configHelper = new ConfigurationHelper();
            configHelper.write(config);
            config = null;

            config = configHelper.deserialize("");


            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void border_grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void reloadButtons()
        {
            buttonHolder.Children.RemoveRange(0, buttonHolder.Children.Count);//remove them all

            foreach (Game a in games)
            {
                GameButton dynamicb = new GameButton(a);
                dynamicb.Content = a.Name;
                buttonHolder.Children.Add(dynamicb);
                dynamicb.Click += GButton_ClicK;
            }

        }

        private void search(string val)
        {
            buttonHolder.Children.RemoveRange(0, buttonHolder.Children.Count);//remove them all

            foreach (Game a in games)
            {
                if (a.Name.ToLower().Contains(val.ToLower()))
                {
                    GameButton dynamicb = new GameButton(a);
                    dynamicb.Content = a.Name;
                    buttonHolder.Children.Add(dynamicb);
                    dynamicb.Click += GButton_ClicK;
                }
            }


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            System.Windows.Controls.TextBox searchTerm = (System.Windows.Controls.TextBox)sender;
            if (searchTerm.Text != "")
                search(searchTerm.Text);
            else
                reloadButtons();
        }
    }
}

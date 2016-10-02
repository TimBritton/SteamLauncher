using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SteamLauncher.Core;
using System.IO;

namespace SteamLauncher
{
	/// <summary>
	/// Interaction logic for DirectoryFinder.xaml
	/// </summary>
	public partial class DirectoryFinder : Window
	{
		public DirectoryFinder()
		{
			this.InitializeComponent();
          
			// Insert code required on object creation below this point.
            try
            {
                ConfigurationHelper conHelp = new ConfigurationHelper();
                var config = conHelp.deserialize("");
                spawn(config);
            }
            catch (FileNotFoundException fe)
            { 
            
            
            }

		}

        private void spawn(LauncherConfig config)
        {
            var spawn = new SteamLauncher.MainWindow(config.SteamDirectory);
            spawn.Show();
            this.Close();


        }


        internal string getResult()
        {
            if (folderEntry.hasResults())
                return folderEntry.Text;
            else
                return null;
        }

        private void folderEntry_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(folderEntry.Text))
            {
                if (folderEntry.Text.ToLower().Contains("steamapps"))
                {
                    var spawn = new SteamLauncher.MainWindow(folderEntry.Text);
                    spawn.Show();
                    this.Close();
                }
                }
            }
    }
}
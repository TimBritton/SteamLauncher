using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SteamLauncher.Core
{
    public class GameButton : Button
    {
        Game _game;

        public Game Game
        {
            get { return _game; }
            set { _game = value; }
        }

        public GameButton() { }
        public GameButton(Game game)
        {
            _game = game;
            Width = 80;
            Height = 80;
            this.Content = _game.Name;
            SolidColorBrush BackgroundButtonColor = new SolidColorBrush(
                Color.FromArgb
                (
                 255, // Specifies the transparency of the color.
                 15, // Specifies the amount of red.
                 30, // specifies the amount of green.
                 32) // Specifies the amount of blue.
                );
            this.Background = BackgroundButtonColor;

            SolidColorBrush TextColor = new SolidColorBrush(
                Color.FromArgb
                (
                255, // Specifies the transparency of the color.
                93, // Specifies the amount of red.
                93, // specifies the amount of green.
                93) // Specifies the amount of blue.
                  );

            this.Foreground = TextColor;
              
        }
        
        

    }
}

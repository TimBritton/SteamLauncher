using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
using System.Xml.Serialization;

namespace SteamLauncher.Core
{
  public class Game : IComparable<Game>
    {

      public Game() { }
      private string _name;
       [XmlElement("name")]
      public string Name
      {
          get { return _name; }
          set { _name = value; }
      }
      private int _id;
      [XmlElement("appId")]
      public int Id
      {
          get { return _id; }
          set { _id = value; }
      }
      public Game(string name, int id)
      {
          _name = name;
          _id = id;
      }

      public void run()
      {
          try
          {
              Process.Start("steam://rungameid/" + _id);
          }
          catch (Exception e)
          {
              //write the error and display message box #TODO
          }
      }




      public int CompareTo(Game other)
      {
          return (_name.CompareTo(other.Name));
      }
    }
}

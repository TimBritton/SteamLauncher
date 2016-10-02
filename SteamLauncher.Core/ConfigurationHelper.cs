using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamLauncher.Core;
using System.Xml.Serialization;
using System.IO;

namespace SteamLauncher.Core
{
    public class ConfigurationHelper
    {
        public ConfigurationHelper()
        { }

        public void write(LauncherConfig serializedConfig)
        {
            XmlSerializer game_serializer = new XmlSerializer(typeof(LauncherConfig));

            TextWriter writer = new StreamWriter("LauncherConfig.xml");

            game_serializer.Serialize(writer, serializedConfig);
            writer.Close();

        }

        public LauncherConfig deserialize(string filename) 
        {
            XmlSerializer game_serializer = new XmlSerializer(typeof(LauncherConfig));
            FileStream fileStream;
            try
            {
                fileStream = new FileStream("LauncherConfig.xml", FileMode.Open);
            }
            catch(FileNotFoundException fe)
            {
                throw;
            
            }
            var newconfig = (LauncherConfig)game_serializer.Deserialize(fileStream);
            fileStream.Close();
            return (newconfig);
        
        }



    }
}

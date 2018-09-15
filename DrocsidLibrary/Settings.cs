using System.IO;
using Newtonsoft.Json;

namespace DrocsidLibrary
{
    public class Settings
    {
        [JsonProperty]
        public bool ShowDebugLogs { get; set; }

        public void SerialiseToFile()
        {
            File.WriteAllText(Constants.SettingsPath, JsonConvert.SerializeObject(this, Formatting.Indented));
        }

        public static Settings DeserialseFromFile()
        {
            if (!File.Exists(Constants.SettingsPath)) return new Settings();
            return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(Constants.SettingsPath));
        }
    }
}
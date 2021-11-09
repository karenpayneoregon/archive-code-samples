using System;
using System.IO;
using Newtonsoft.Json;

namespace FormsLibrary.Classes
{
    /// <summary>
    /// Initial creation of configuration.json
    /// </summary>
    public class ConfigurationOperations
    {
        public static string JsonFileName => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "configuration.json");
        public static void Save(Configuration source)
        {
            File.WriteAllText(JsonFileName, JsonConvert.SerializeObject(source, Formatting.Indented));
        }

        /// <summary>
        /// Read the configuration from disk
        /// </summary>
        /// <returns></returns>
        public static Configuration Read() => JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(JsonFileName));
    }
}
using Newtonsoft.Json;
using System.IO;
using System.Windows;

namespace WpfApp1
{
    internal static class Json
    {
        public static void Serialize<T>(T obj, string filePath)
        {
            string json = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static T Deserialize<T>(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                T obj = JsonConvert.DeserializeObject<T>(json)!;
                return obj;
            }
            else return default(T)!;
        }
    }
}
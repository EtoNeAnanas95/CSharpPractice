using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WpfApp1
{
    internal static class Function
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
                T obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }
            else
            {
                Console.WriteLine("Json по данному пути не существует");
                return default(T);
            }
        }
    }
}

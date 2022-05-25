using System.IO;
using Newtonsoft.Json;

namespace Serialization {
    
    public static class Serializator {

        public static void SerializeData(object data, string savePath) {
            string serializedData = JsonConvert.SerializeObject(data);
            File.WriteAllText(savePath, serializedData);
        }

        public static T DeserializeData<T>(string savePath) {
            if (File.Exists(savePath)) {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(savePath));
            }
            return default (T);
        }
        
    }
    
}
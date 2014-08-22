using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Rosalind.Core.Utilities {
    public class JsonLoader {
        public static List<T> LoadList<T>(string relativePath){
            var path = Directory.GetCurrentDirectory();
            var fullName = Path.Combine(path, relativePath);
            using(var reader = File.OpenText(fullName)){
                var data = reader.ReadToEnd();
                var deserialized = JsonConvert.DeserializeObject<List<T>>(data);
                return deserialized;
            }
        }
    }
}

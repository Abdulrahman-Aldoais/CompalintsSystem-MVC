using Newtonsoft.Json;
using System.IO;

namespace CompalintsSystem.EF.Repositories
{
    public static class JsonFileConvertAndSave
    {
        private static readonly JsonSerializerSettings _options
               = new() { NullValueHandling = NullValueHandling.Ignore };

        public static void SimpleWrite(object obj, string fileName)
        {
            var jsonString = JsonConvert.SerializeObject(obj, _options);
            File.WriteAllText(fileName, "{\"data\":" + jsonString + "}");
        }
        public static string GetDataFromObjet(object obj)
        {
            return JsonConvert.SerializeObject(obj, _options);
        }

    }
}

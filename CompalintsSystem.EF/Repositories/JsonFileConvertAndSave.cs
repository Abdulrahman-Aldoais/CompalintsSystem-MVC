using Newtonsoft.Json;
using System.IO;

namespace CompalintsSystem.EF.Repositories
{
    // صنف ثابت (Static Class) يوفر وظائف لتحويل كائنات C# إلى ملف JSON وحفظه في ملف بشكل بسيط، وكذلك الحصول على بيانات JSON من كائن C#.
    public static class JsonFileConvertAndSave
    {
        // إعدادات JsonSerializer لتحويل كائن C# إلى JSON
        private static readonly JsonSerializerSettings _options
            = new() { NullValueHandling = NullValueHandling.Ignore };

        // تحويل كائن C# إلى ملف JSON وحفظه في ملف بشكل بسيط
        public static void SimpleWrite(object obj, string fileName)
        {
            var jsonString = JsonConvert.SerializeObject(obj, _options);
            File.WriteAllText(fileName, "{\"data\":" + jsonString + "}");
        }

        // الحصول على بيانات JSON من كائن C#
        public static string GetDataFromObjet(object obj)
        {
            return JsonConvert.SerializeObject(obj, _options);
        }
    }
}

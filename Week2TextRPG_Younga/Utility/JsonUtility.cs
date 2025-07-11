using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Week2TextRPG_Younga.Utility
{
    public static class JsonUtility
    {
        //json파일 위치.
        public static string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\") + "\\Jsons";
        public static JsonSerializerSettings GetJsonSetting()
        {
            JsonSerializerSettings setting = new JsonSerializerSettings();
            setting.Converters.Add(new StringEnumConverter());
            return setting;
        }
    }
}

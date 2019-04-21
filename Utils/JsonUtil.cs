using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveAnim.Utils
{
    public class JsonUtil
    {
        private static JsonSerializer jsonSerializer = new JsonSerializer();
        public static T JsonToObject<T>(string json)
        {
            T result = jsonSerializer.Deserialize<T>(new JsonTextReader(new StringReader(json)));
            return result;
        }
    }
}

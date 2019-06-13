using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace weatherappapi.Repositories
{
    public static class StreamHelper
    {
        public static async Task<T> DeserializeJsonFrom<T>(IMapper mapper, Stream stream, string startFromToken = null)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);

            using (var sr = new StreamReader(stream))
                return await ReadStream<T>(mapper, startFromToken, sr);
        }

        public static async Task<T> DeserializeJsonFrom<T>(IMapper mapper, string content, string startFromToken = null)
        {
            if (content == null)
                return default(T);

            using (var sr = new StringReader(content))
                return await ReadStream<T>(mapper, startFromToken, sr);
        }

        private static async Task<T> ReadStream<T>(IMapper mapper, string startFromToken, TextReader sr)
        {
            using (var jtr = new JsonTextReader(sr))
            {
                var jsonObject = await JToken.ReadFromAsync(jtr);
                if (startFromToken != null)
                    jsonObject = jsonObject.SelectToken(startFromToken);
                return mapper.Map<T>(jsonObject);
            }
        }

        public static async Task<string> StreamToStringAsync(Stream stream)
        {
            string content = null;

            if (stream != null)
                using (var sr = new StreamReader(stream))
                    content = await sr.ReadToEndAsync();

            return content;
        }
    }
}

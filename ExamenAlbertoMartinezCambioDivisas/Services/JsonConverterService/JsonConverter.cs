using System.Collections.Generic;
using Newtonsoft.Json;

namespace ExamenAlbertoMartinezCambioDivisas.Services.JsonConverterService
{
    public class JsonConverter<T> : IJsonConverter<T> where T : class
    {
        public List<T> DeserializeJson(string content)
        {
            return JsonConvert.DeserializeObject<List<T>>(content);
        }
    }
}
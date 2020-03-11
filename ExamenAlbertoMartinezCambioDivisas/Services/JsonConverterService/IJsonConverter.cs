using System.Collections.Generic;

namespace ExamenAlbertoMartinezCambioDivisas.Services.JsonConverterService
{
    public interface IJsonConverter<T> where T : class
    {
        List<T> DeserializeJson(string content);

    }
}

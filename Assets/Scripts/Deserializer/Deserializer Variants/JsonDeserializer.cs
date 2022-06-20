using UnityEngine;

namespace Deserializer.Deserializer_Variants
{
    public class JsonDeserializer : IDeserializer
    {
        public T Execute<T>(string deserializeData) where T : class, IDeserialized
        {
            string correctJson = deserializeData.Replace("\'", "\"");
            return JsonUtility.FromJson<T>(correctJson);
        }
    }
}
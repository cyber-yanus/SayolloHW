using System.IO;
using System.Xml.Serialization;

namespace Deserializer.Deserializer_Variants
{
    public class XmlDeserializer : IDeserializer
    {
        public T Execute<T>(string deserializeData) where T : class, IDeserialized
        {
            XmlSerializer serializer = new XmlSerializer (typeof(T));
            
            using (TextReader reader = new StringReader(deserializeData))
            {
                return serializer.Deserialize(reader) as T;
            }
        }
    }
}
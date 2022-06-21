namespace Deserializer
{
    public interface IDeserializer
    {
        T Execute<T>(string deserializeData) where T : class, IDeserialized;
    }
}
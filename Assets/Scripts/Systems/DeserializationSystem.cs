using Deserializer.Deserializer_Variants;
using Data.ResponseData;
using DefaultNamespace;
using Data.NetworkData;
using Deserializer;
using Data.ApiData;
using Xml2CSharp;
using System;

namespace Systems
{
    public class DeserializationSystem
    {
        private readonly NetworkConfig _networkConfig;

        private Action<IDeserialized> _deserializationCompleted;
        
        

        public DeserializationSystem(NetworkConfig networkConfig)
        {
            _networkConfig = networkConfig;
        }

        public void Activate(ApiType apiType, string response)
        {
            switch (apiType)
            {
                case ApiType.VideoAds:
                    Deserialize<VAST>(apiType, response);
                    break;
                
                case ApiType.PurchaseItem:
                    Deserialize<PurchaseItemData>(apiType, response);
                    break;
            }
        }

        public void AddDeserializationCompletedAction(Action<IDeserialized> action)
        {
            _deserializationCompleted = action;
        }

        private void Deserialize<T>(ApiType apiType, string response) where T : class, IDeserialized
        {
            var deserializer = SelectDeserializer(apiType);
            
            T deserializedObject = deserializer.Execute<T>(response);
            
            _deserializationCompleted?.Invoke(deserializedObject);
        }

        private IDeserializer SelectDeserializer(ApiType apiType)
        {
            var responseFormat = _networkConfig.GetResponseFormatByApiType(apiType);

            switch (responseFormat)
            {
                case ResponseFormat.Xml:
                    return new XmlDeserializer();
                
                case ResponseFormat.Json:
                    return new JsonDeserializer();
            }

            return null;
        }
        
        
    }
}
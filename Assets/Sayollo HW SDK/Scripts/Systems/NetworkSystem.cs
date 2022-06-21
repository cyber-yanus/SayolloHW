using Data.NetworkData;
using Data.ApiData;
using Deserializer;
using UnityEngine;
using System;


namespace Systems
{
    public class NetworkSystem : MonoBehaviour
    {
        [SerializeField] private NetworkConfig networkConfig;

        private RequestSystem _requestSystem;
        private DeserializationSystem _deserializationSystem;

        
        
        private void Awake()
        {
            Init();
        }

        public void ActivateApiRequest(ApiType apiType, Action<IDeserialized> afterDeserializationAction = null)
        {
            _deserializationSystem.AddDeserializationCompletedAction(afterDeserializationAction);

            _requestSystem.SendApiRequest(apiType);
        }

        public void ActivateSpriteRequest(string spriteUrl, Action<Sprite> afterSpriteRequestAction)
        {
            _requestSystem.AddSpriteResponseReceivedAction(afterSpriteRequestAction);
            
            _requestSystem.SendSpriteRequest(spriteUrl);
        }

        
        public void AddRequestJsonToApi(string json, ApiType apiType)
        {
            networkConfig.AddJsonToApi(json, apiType);
        }

        private void Init()
        {
            _requestSystem = new RequestSystem(networkConfig);
            _deserializationSystem = new DeserializationSystem(networkConfig);

            _requestSystem.ApiResponseReceived += _deserializationSystem.Activate;
        }
        
    }
}

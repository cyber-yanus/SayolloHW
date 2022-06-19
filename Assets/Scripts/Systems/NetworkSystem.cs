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

        public void ActivateRequest(ApiType apiType, Action<IDeserialized> afterDeserializationAction = null)
        {
            _deserializationSystem.AddDeserializationCompletedAction(afterDeserializationAction);

            _requestSystem.SendRequest(apiType);
        }

        private void Init()
        {
            _requestSystem = new RequestSystem(networkConfig);
            _deserializationSystem = new DeserializationSystem(networkConfig);

            _requestSystem.ResponseReceived += _deserializationSystem.Activate;
        }
        
    }
}

using Cysharp.Threading.Tasks;
using UnityEngine.Networking;
using Data.RequestData;
using Data.NetworkData;
using Data.ApiData;
using UnityEngine;
using System;

namespace Systems
{
    public class RequestSystem
    {
        private readonly NetworkConfig _networkConfig;
        
        public event Action<ApiType, string> ResponseReceived;
        

        
        public RequestSystem (NetworkConfig networkConfig)
        {
            _networkConfig = networkConfig;
        }

        public async UniTask SendRequest(ApiType apiType)
        {
            UnityWebRequest request = SelectRequest(apiType);

            await request.SendWebRequest();

            if (!string.IsNullOrEmpty(request.error))
            {
                Debug.LogError(request.error);
            }
            else
            {
                string response = request.downloadHandler.text;
                
                ResponseReceived?.Invoke(apiType, response);
                
                Debug.Log(request.downloadHandler.text);
            }
        }

        private UnityWebRequest SelectRequest(ApiType apiType)
        {
            var requestType = _networkConfig.GetRequestTypeByApiType(apiType);
            var requestPath = _networkConfig.GetFullApiPath(apiType);

            switch (requestType)
            {
                case RequestType.Get:
                    return GetRequest(requestPath);

                case RequestType.Post:
                    var formData = _networkConfig.GetFormDataByApiType(apiType);
                    return PostRequest(requestPath, formData);
            }

            return null;
        }

        private UnityWebRequest GetRequest(string requestPath)
        {
            return UnityWebRequest.Get(requestPath);
        }

        private UnityWebRequest PostRequest(string requestPath, WWWForm formData)
        {
            return UnityWebRequest.Post(requestPath, formData);
        }
    }
}
using System;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;
using Data.NetworkData;
using Data.RequestData;
using Data.ApiData;
using UnityEngine;

namespace Systems
{
    public class NetworkSystem : MonoBehaviour
    {
        [SerializeField] private NetworkConfig networkConfig;


        private void Start()
        {
            SendRequest(ApiType.VideoAds);
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
                Debug.Log(request.downloadHandler.text);
            }
        }

        private UnityWebRequest SelectRequest(ApiType apiType)
        {
            var requestType = networkConfig.GetRequestTypeByApiType(apiType);
            var requestPath = networkConfig.GetFullApiPath(apiType);

            switch (requestType)
            {
                case RequestType.Get:
                    return GetRequest(requestPath);

                case RequestType.Post:
                    var formData = networkConfig.GetFormDataByApiType(apiType);
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

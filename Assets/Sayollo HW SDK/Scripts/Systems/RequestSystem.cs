using Cysharp.Threading.Tasks;
using UnityEngine.Networking;
using Data.RequestData;
using Data.NetworkData;
using Data.ApiData;
using UnityEngine;
using System.Text;
using System;

namespace Systems
{
    public class RequestSystem
    {
        private readonly NetworkConfig _networkConfig;
        
        public event Action<ApiType, string> ApiResponseReceived;
        private Action<Sprite> SpriteResponseReceived;



        public RequestSystem (NetworkConfig networkConfig)
        {
            _networkConfig = networkConfig;
        }

        public async UniTask SendApiRequest(ApiType apiType)
        {
            UnityWebRequest request = SelectRequest(apiType);

            if (request == null)
            {
                Debug.LogError("you can't send a request");
                return;
            }
            
            await request.SendWebRequest();

            if (!string.IsNullOrEmpty(request.error))
            {
                Debug.LogError(request.error);
            }
            else
            {
                string response = request.downloadHandler.text;
                
                Debug.Log($"response = " + response);
                
                ApiResponseReceived?.Invoke(apiType, response);
            }
        }

        public async UniTask SendSpriteRequest(string spriteUrl)
        {
            UnityWebRequest request = GetRequest(spriteUrl);
            
            await request.SendWebRequest();
            
            if (!string.IsNullOrEmpty(request.error))
            {
                Debug.LogError(request.error);
            }
            else
            {
                byte[] response = request.downloadHandler.data;
                Sprite spriteResult = response.ToSprite();
                
                SpriteResponseReceived?.Invoke(spriteResult);
            }
        }

        public void AddSpriteResponseReceivedAction(Action<Sprite> action)
        {
            SpriteResponseReceived = action;
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
                    var requestJson = _networkConfig.GetRequestJsonByApiType(apiType);
                    return PostRequest(requestPath, requestJson);
            }

            return null;
        }

        private UnityWebRequest GetRequest(string requestPath)
        {
            return UnityWebRequest.Get(requestPath);
        }

        private UnityWebRequest PostRequest(string requestPath, string requestJson)
        {
            if (string.IsNullOrEmpty(requestJson))
            {
                Debug.LogError("request json is empty");
                return null;
            }
            
            UnityWebRequest request = new UnityWebRequest(requestPath, "POST"); 
            
            var jsonToSend = new UTF8Encoding().GetBytes(requestJson);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            return request;
        }
    }
}
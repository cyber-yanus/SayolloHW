using Data.ResponseData;
using Data.RequestData;
using UnityEngine;
using System;


namespace Data.ApiData
{
    [Serializable]
    public class ApiData : CustomDictionaryData<ApiType, string>
    {
        [Space]
        [SerializeField] private RequestType requestType;
        [Space]
        [SerializeField] private ResponseFormat responseFormat;

        private string _requestJson;


        public RequestType RequestType => requestType;

        public ResponseFormat ResponseFormat => responseFormat;

        public string RequestJson
        {
            get => _requestJson;
            set => _requestJson = value;
        }
    }
}
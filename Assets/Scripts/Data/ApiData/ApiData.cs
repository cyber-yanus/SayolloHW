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
        [SerializeField] private RequestFormsDataConfig requestFormsDataConfig;
        [Space]
        [SerializeField] private ResponseFormat responseFormat;
        

        public RequestType RequestType => requestType;
        public RequestFormsDataConfig RequestFormsDataConfig => requestFormsDataConfig;
        
        public ResponseFormat ResponseFormat => responseFormat;
    }
}
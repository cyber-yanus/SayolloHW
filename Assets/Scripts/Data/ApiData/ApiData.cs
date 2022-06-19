using Data.RequestData;
using UnityEngine;
using System;

namespace Data.ApiData
{
    [Serializable]
    public class ApiData : CustomDictionaryData<ApiType, string>
    {
        [SerializeField] private RequestType requestType;
        [SerializeField] private RequestFormsDataConfig requestFormsDataConfig;
        
        public RequestType RequestType => requestType;
        public RequestFormsDataConfig RequestFormsDataConfig => requestFormsDataConfig;
    }
}
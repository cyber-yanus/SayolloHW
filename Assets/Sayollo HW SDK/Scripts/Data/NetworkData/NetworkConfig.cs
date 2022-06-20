using Data.EnvironmentData;
using Data.ResponseData;
using Data.RequestData;
using Data.ApiData;
using UnityEngine;

namespace Data.NetworkData
{
    [CreateAssetMenu(fileName = "Network Config", menuName = "Data/Network Config")]
    public class NetworkConfig : ScriptableObject
    {
        [SerializeField] private string mainServerUrl;
        
        [Header("Environments config")]
        [SerializeField] private EnvironmentType currentEnvironmentType;
        [SerializeField] private EnvironmentsConfig environmentsConfig;

        [Header("Apis")] 
        [SerializeField] private ApisConfig apisConfig;
        
        
        
        public string GetFullApiPath(ApiType apiType)
        {
            var environmentData = environmentsConfig.GetDataByType(currentEnvironmentType);
            var apiData = apisConfig.GetDataByType(apiType);

            string environmentValue = environmentData.Value;
            string apiValue = apiData.Value;

            string fullApiPath = $"{mainServerUrl}{environmentValue}{apiValue}";

            return fullApiPath;
        }

        public RequestType GetRequestTypeByApiType(ApiType apiType)
        {
            var apiData = apisConfig.GetDataByType(apiType);
            
            return apiData.RequestType;
        }

        public ResponseFormat GetResponseFormatByApiType(ApiType apiType)
        {
            var apiData = apisConfig.GetDataByType(apiType);

            return apiData.ResponseFormat;
        }

        public string GetRequestJsonByApiType(ApiType apiType)
        {
            var apiData = apisConfig.GetDataByType(apiType);

            return apiData.RequestJson;
        }

        public void AddJsonToApi(string json, ApiType apiType)
        {
            var apiData = apisConfig.GetDataByType(apiType);

            apiData.RequestJson = json;
        }
    }
}
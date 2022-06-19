using UnityEngine;

namespace Data.ApiData
{
    [CreateAssetMenu(fileName = "Apis Config", menuName = "Data/Apis Config")]
    public class ApisConfig : BaseDictionaryConfig<ApiData, ApiType, string>
    {
    }
}
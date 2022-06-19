using UnityEngine;


namespace Data.EnvironmentData
{
    [CreateAssetMenu(fileName = "Environments Config", menuName = "Data/Environments Config")]
    public class EnvironmentsConfig : BaseDictionaryConfig<EnvironmentData, EnvironmentType, string>
    {
    }
}
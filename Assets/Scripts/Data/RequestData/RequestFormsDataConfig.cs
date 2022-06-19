using UnityEngine;

namespace Data.RequestData
{
    [CreateAssetMenu(fileName = "Form Data Config", menuName = "Data/Form Data Config")]
    public class RequestFormsDataConfig : BaseDictionaryConfig<RequestFormData, string, string>
    {
        public WWWForm GetWWWForm()
        {
            WWWForm resultForm = new WWWForm();
            
            foreach (var data in dataList)
            {
                string dataKey = data.Key;
                string dataValue = data.Value;
                
                resultForm.AddField(dataKey, dataValue);
            }

            return resultForm;
        }
    }
}
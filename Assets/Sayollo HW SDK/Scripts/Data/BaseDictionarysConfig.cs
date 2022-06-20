using UnityEngine;
using System;


namespace Data
{
    [Serializable]
    public abstract class BaseDictionaryConfig<TData, TKey, TValue> : ScriptableObject 
        where TData : CustomDictionaryData<TKey, TValue>
    {
        [SerializeField] protected TData[] dataList;
        
        
        
        public TData GetDataByType(TKey type)
        {
            foreach (var data in dataList)
            {
                var environmentType = data.Key;
                if (environmentType.Equals(type))
                {
                    return data;
                }
            }
            
            return null;
        }
    }
}
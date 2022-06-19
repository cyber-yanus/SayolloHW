using UnityEngine;
using System;


namespace Data
{
    [Serializable]
    public abstract class CustomDictionaryData<TKey, TValue>
    {
        [SerializeField] private TKey dataKey;
        [SerializeField] private TValue DataValue;

        public TKey Key => dataKey;
        public TValue Value => DataValue;
    }
}
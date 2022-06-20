using Deserializer;
using System;

namespace DefaultNamespace
{
    [Serializable]
    public class PurchaseResultData : IDeserialized
    {
        public string user_message;
        public string status;
        public int error_code;
    }
}
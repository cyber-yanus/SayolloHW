using UnityEngine.UI;
using UnityEngine;

namespace Ui.Screen
{
    public class PurchaseResultUi : MonoBehaviour
    {
        [SerializeField] private Text result;



        public void Activate(bool value)
        {
            gameObject.SetActive(value);
        }

        public void AddResult(string value)
        {
            result.text = value;
        }
        
    }
}
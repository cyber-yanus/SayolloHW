using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace Ui
{
    public class ConfirmPurchaseUi : MonoBehaviour
    {
        [SerializeField] private Button confirmButton;
        [SerializeField] private Button backButton;
        [Space] 
        [SerializeField] private TMP_InputField email;
        [SerializeField] private TMP_InputField cardNumber;
        [SerializeField] private TMP_InputField cardExpirationMonth;
        [SerializeField] private TMP_InputField cardExpirationYear;

        public string EmailValue => email.text;
        public string CardNumberValue => cardNumber.text;
        public string CardDateValue => $"{cardExpirationMonth.text}/{cardExpirationYear.text}";

        
        
        public void Activate(bool value)
        {
            gameObject.SetActive(value);
        }

        public void AddConfirmPurchaseAction(UnityAction action)
        {
            confirmButton.onClick.AddListener(action);
        }

        public void AddBackButtonAction(UnityAction action)
        {
            backButton.onClick.AddListener(action);
        }
        
    }
}
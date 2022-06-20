using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

namespace Ui.Screen
{
    public class PurchaseScreen : MonoBehaviour
    {
        [SerializeField] private Button sendButton;
        [SerializeField] private GameObject loadPanel;

        

        public void SetActiveLoadPanel(bool value)
        {
            loadPanel.SetActive(value);
        }

        public void SetActiveSendButton(bool value)
        {
            sendButton.gameObject.SetActive(value);
        }
        
        public void AddActionToSendButton(UnityAction action)
        {
            sendButton.onClick.AddListener(action);
        }
    }
}
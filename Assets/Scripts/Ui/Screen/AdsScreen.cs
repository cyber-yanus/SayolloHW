using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;


namespace Screen
{
    public class AdsScreen : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private GameObject loadPanel;
        [SerializeField] private Text loadPanelTextMeshPro;



        public void SetActiveLoadPanel(bool value)
        {
            loadPanel.SetActive(value);
        }

        public void SetActivePlayButton(bool value)
        {
            playButton.gameObject.SetActive(value);
        }

        public void AddLoadPanelText(string loadPanelText)
        {
            loadPanelTextMeshPro.text = loadPanelText;
        }

        public void AddActionForPlayButton(UnityAction action)
        {
            playButton.onClick.AddListener(action);
        }
    }
}
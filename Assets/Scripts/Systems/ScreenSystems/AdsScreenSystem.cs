using UnityEngine.Video;
using Data.ApiData;
using Deserializer;
using UnityEngine;
using Xml2CSharp;
using Ui.Screen;

namespace Systems
{
    public class AdsScreenSystem : MonoBehaviour
    {
        [SerializeField] private AdsScreen adsScreen; 
        [Space]
        [SerializeField] private NetworkSystem networkSystem;
        [SerializeField] private VideoSystem videoSystem;

        private const string LoadPanelRequestText = "Processes the request ...";
        private const string LoadPanelVideoText = "Loading video ...";
        
        private const string VideoUrlKey = "video url";



        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            adsScreen.AddActionForPlayButton(PLayButtonAction);
            
            videoSystem.SetupVideoEndAction(VideoEndedAction);
            videoSystem.SetupVideoStartAction(VideoStartAction);
        }

        private void PLayButtonAction()
        {
            adsScreen.SetActiveLoadPanel(true);
            adsScreen.SetActivePlayButton(false);
            
            if (PlayerPrefs.HasKey(VideoUrlKey))
            {
                string videoUrl = PlayerPrefs.GetString(VideoUrlKey);
                PLayVideoAction(videoUrl);
            }
            else
            {
                adsScreen.AddLoadPanelText(LoadPanelRequestText);
                networkSystem.ActivateApiRequest(ApiType.VideoAds, RequestFinishAction);
            }
        }

        private void PLayVideoAction(string videoUrl)
        {
            adsScreen.AddLoadPanelText(LoadPanelVideoText);
            
            videoSystem.SetupUrlVideo(videoUrl);
            videoSystem.Play();
        }

        private void RequestFinishAction(IDeserialized deserializedObject)
        {
            VAST vast = (VAST) deserializedObject;

            string videoUrl = vast.Ad.InLine.Creatives.Creative.Linear.MediaFiles.MediaFile;

            PLayVideoAction(videoUrl);
            
            PlayerPrefs.SetString(VideoUrlKey, videoUrl);
        }

        private void VideoStartAction(VideoPlayer videoPlayer)
        {
            adsScreen.SetActiveLoadPanel(false);
        }

        private void VideoEndedAction(VideoPlayer videoPlayer)
        {
            videoSystem.Stop();
            adsScreen.SetActivePlayButton(true);
        }
    }
}
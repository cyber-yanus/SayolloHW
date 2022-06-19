using UnityEngine.Video;
using UnityEngine;

namespace Systems
{
    public class VideoSystem : MonoBehaviour
    {
        [SerializeField] private VideoPlayer videoPlayer;

        

        public void Play()
        {
            videoPlayer.Play();
        }

        public void Stop()
        {
            videoPlayer.Stop();
        }

        public void SetupUrlVideo(string videoUrl)
        {
            videoPlayer.url = videoUrl;
        }

        public void SetupVideoEndAction(VideoPlayer.EventHandler endVideoAction)
        {
            videoPlayer.loopPointReached += endVideoAction;
        }
        
        public void SetupVideoStartAction(VideoPlayer.EventHandler startVideoAction)
        {
            videoPlayer.started += startVideoAction;
        }
    }
}
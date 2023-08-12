using System;
using UnityEngine;
using UnityEngine.Video;

public class SplashScene : MonoBehaviour
{
    public static event Action VideoFinished;
    [SerializeField] private string videoFileName;

    private void Start()
    {
        PlayVideo();
    }

    public void PlayVideo()
    {
        VideoPlayer player = GetComponent<VideoPlayer>();

        if (player)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            player.url = videoPath;

            player.Play();
        }

        player.loopPointReached += FinishedVideo;
    }

    private void FinishedVideo(VideoPlayer sp)
    {
        VideoFinished?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PortaitVideo : MonoBehaviour
{


    public VideoPlayer videoPlayer;
    public string filesLocation  = "C:/Users/Carolin/Google Drive/XOrdner/webcam_terminal";

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.url = filesLocation;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.Prepare();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SceneController : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public GameObject videoPlayerLogo;
    public GameObject videoPlayerUi;


    // Start is called before the first frame update
    void Start()
    {
        videoPlayerLogo.SetActive(false);
        videoPlayerUi.SetActive(false);

    }

    // Update is called once per frame

        
    void Update()
    
    {
  
        if (Input.GetKey(KeyCode.S))
            {
            playableDirector.Play();
            videoPlayerLogo.SetActive(true);
            videoPlayerUi.SetActive(true);
            Debug.Log("Start");
        }
        if (Input.GetKey(KeyCode.P))
        {
            playableDirector.Pause();
            Debug.Log("Pause");
        }
        if (Input.GetKey(KeyCode.C))
        {
            playableDirector.Stop();
            videoPlayerLogo.SetActive(false);
            videoPlayerUi.SetActive(false);
            Debug.Log("Cancle/Restart");
        }
        if (Input.GetKey(KeyCode.R))
        {
            playableDirector.Resume();
            Debug.Log("Resume");
        }
    }
}

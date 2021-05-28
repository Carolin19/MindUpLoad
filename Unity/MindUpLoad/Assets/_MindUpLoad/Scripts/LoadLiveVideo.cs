using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoadLiveVideo : MonoBehaviour
{

    public int currentCamIndex = 0;
    WebCamTexture tex;
    public RawImage display;

    private void Start()
    {
        if (WebCamTexture.devices.Length > 0)
        {
      
            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;
            tex.Play();

            Debug.Log(WebCamTexture.devices.Length);
        }
    }

}

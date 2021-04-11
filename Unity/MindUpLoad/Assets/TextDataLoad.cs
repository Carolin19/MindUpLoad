using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;
using DG.Tweening;

public class TextDataLoad : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI uiNameText;

    string fileLocation = "C:/Users/Carolin/Google Drive/XOrdner/GoogleText/googletext.txt";

    public IEnumerator Start()
    {
        yield return StartCoroutine(

        "GetData",
            value: fileLocation
        );


    }


    IEnumerator GetData(string url)
    {
#pragma warning disable CS0618 // Type or member is obsolete



        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.Send();

        if (request.isNetworkError)
        {
            //error
            Debug.Log("testfail");
        }
        else
        {
            //success
            Debug.Log("Erfolg");
            Debug.Log(request.downloadHandler.text);
            StartCoroutine(
                "LoadTextOnCanvas", request.downloadHandler.text);
                
        }
#pragma warning restore CS0618 // Type or member is obsolete

    }

    IEnumerator LoadTextOnCanvas(string text)
    {
        yield return uiNameText.text = text;

    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DataDesktop : MonoBehaviour
{
  
    [SerializeField] Text uiNameText;
    [SerializeField] RawImage uiRawImage;
    [SerializeField] RawImage uiRawImage01;
    [SerializeField] RawImage uiRawImage02;
    [SerializeField] RawImage uiRawImage03;
    [SerializeField] RawImage uiRawImage04;
    [SerializeField] RawImage uiRawImage05;
    [SerializeField] RawImage uiRawImage06;
    [SerializeField] RawImage uiRawImage07;
    [SerializeField] RawImage uiRawImage08;
    [SerializeField] RawImage uiRawImage09;
    [SerializeField] RawImage uiRawImage10;
    [SerializeField] RawImage uiRawImage11;
    [SerializeField] RawImage uiRawImage12;
    [SerializeField] RawImage uiRawImage13;
    [SerializeField] RawImage uiRawImage14;
    [SerializeField] RawImage uiRawImage15;
    


    //public string Name;
    //public string ImageURL;


    private string myFile;
    //private Random rand = new Random();

    public string filesLocation = @"C:\Users\Carolin\Google Drive\XOrdner\GoogleImages\bildersuche1";
    public List<Texture2D> images = new List<Texture2D>();

    private object texture;
    private readonly object load;

    public object CreateRawimage { get; private set; }

    public IEnumerator Start()
    {
        yield return StartCoroutine(

        "LoadAll",
            value: Directory.GetFiles(filesLocation, "*.jpg", SearchOption.AllDirectories)
        );
    }


    public IEnumerator LoadAll(string[] filePaths)
    {
        foreach (string filePath in filePaths)
        {

#pragma warning disable CS0618 // Type or member is obsolete
            WWW load = new WWW("file://" + filePath);
#pragma warning restore CS0618 // Type or member is obsolete


            yield return load;
            if (!string.IsNullOrEmpty(load.error))
            {
                Debug.LogWarning(filePath + " error");
            }
            else
            //success
            {
                //save image texture in array
                images.Add(load.texture);
                if (images.Count == filePaths.Length)
                {
                    LoadTextures();
                }
            }
        }
    }

    private void LoadTextures()
    {
        Debug.Log("Load Textures");

        int imagesRandomIndex = Random.Range(17, images.Count -1);
        uiRawImage.texture = images[0];
        uiRawImage01.texture = images[1];
        uiRawImage02.texture = images[2];
        uiRawImage03.texture = images[3];
        uiRawImage04.texture = images[4];
        uiRawImage05.texture = images[5];
        uiRawImage06.texture = images[6];
        uiRawImage07.texture = images[7];
        uiRawImage08.texture = images[8];
        uiRawImage09.texture = images[9];
        uiRawImage10.texture = images[10];
        uiRawImage11.texture = images[11];
        uiRawImage12.texture = images[12];
        uiRawImage13.texture = images[13];
        uiRawImage14.texture = images[14];
        uiRawImage15.texture = images[15];

        //TBD
        foreach (Texture2D texture in images)
        {
            CreateRawimage = uiRawImage;
            uiRawImage.texture = texture;
           

        }
    }
}

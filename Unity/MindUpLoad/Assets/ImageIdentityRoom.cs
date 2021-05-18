using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageIdentityRoom : MonoBehaviour
{
    private string myFile;
    public RawImage rawidentityImagePrefab;
    public GameObject identityimageContainer;
    private List<RawImage> rawidentityImageList;


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
                 void LoadTextures()
                {


                    rawidentityImageList = new List<RawImage>();
                    foreach (Texture2D texture in images) ;
                }

                }

            }
    }

}

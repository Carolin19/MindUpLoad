using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;
using DG.Tweening;


public class ImageLoadStaticRoomWall : MonoBehaviour
{
   

    private string myFile;
    public RawImage rawImagePrefab;
    public GameObject imageContainer;
    private List<RawImage> rawImageList;


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


        //int imagesRandomIndex = Random.Range(0, images.Count - 1);

        //hier wird neue Liste erstellt Zeile71
        rawImageList = new List<RawImage>();
        foreach (Texture2D texture in images)

        {
          
            RawImage newImageInstance = Instantiate(rawImagePrefab, new Vector3 (0,0,0), Quaternion.Euler(new Vector3(0, 0, 0)), imageContainer.transform) as RawImage;
            newImageInstance.texture = texture;
            newImageInstance.SetNativeSize();
            rawImageList.Add(newImageInstance);
          
        }
        foreach (RawImage rawImage in rawImageList)
        {
            Vector3 imagePosition = new Vector3(Random.Range(300, 0), Random.Range(400, 0), Random.Range(40, 0));
            rawImage.transform.localPosition = imagePosition;
            rawImage.transform.DOScale(new Vector3(0.085f, 0.085f, 0.085f), 0);
            rawImage.transform.DOLocalRotate(new Vector3(0, 0, 90), 0);

        }
    }
}

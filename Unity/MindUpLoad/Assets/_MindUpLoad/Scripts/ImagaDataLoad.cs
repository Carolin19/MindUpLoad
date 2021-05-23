using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;
using DG.Tweening;

public class ImagaDataLoad : MonoBehaviour
{
    

    private string myFile;
    public  RawImage rawImagePrefab;
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
            Vector3 imagePosition = new Vector3(Random.Range(-28,120), Random.Range(-664,600), Random.Range(110,45));
            RawImage newImageInstance = Instantiate(rawImagePrefab, imagePosition, Quaternion.Euler(new Vector3(0, 0, 0)), imageContainer.transform) as RawImage;
            newImageInstance.texture = texture;
            newImageInstance.SetNativeSize();
            rawImageList.Add(newImageInstance);
        }
        AnimateTextures();
    }

    private void AnimateTextures()
    {
    
        foreach (RawImage rawImage in rawImageList)

        {

           rawImage.transform.DOLocalMove(new Vector3 (0, -60, Random.Range(0,710)),0f);
            rawImage.transform.DOLocalMoveY(Random.Range(0, -10),0.8f).SetDelay(Random.Range(0,2.5f));
            rawImage.transform.DOScale(new Vector3(0.05f,0.05f,0.05f),0);

            rawImage.transform.DORotate(new Vector3(-90, 90, 0), 0);
            rawImage.transform.DOShakePosition(60, new Vector3 (0.05f,0.05f,0.05f));

        }



    }
}
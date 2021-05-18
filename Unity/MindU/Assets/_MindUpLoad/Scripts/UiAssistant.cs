using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiAssistant : MonoBehaviour
{
    private TextMeshProUGUI uiText;
    private string textToWrite;
    private int characterIndex;
    private float timePerCharacter;
    private float timer;
    private TextWriter textWriter;
    private GameObject uiAssistant;
    public TextMeshProUGUI messageText;

    //[SerializeField] private TextWriter textWriter;

    private void Awake()
    {
        Debug.Log("THIS particular script is on " + gameObject.name);
    }

    // Start is called before the first frame update
    private void Start()
    {
       // messageText = uiAssistant.GetComponent<UiAssistant>();
    }

   private void AddWriter(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        characterIndex = 0;
        textWriter.AddWriter(messageText, messageText.text, .2f);
    }
 

    private void Update()
    {
        if (uiText != null)
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                //Display next character
                timer += timePerCharacter;
                characterIndex++;
                uiText.text = textToWrite.Substring(0, characterIndex);

                if (characterIndex >= textToWrite.Length)
                {
                    //Entire string displayed
                    uiText = null;
                    return;
                }
            }

        }
    }

}

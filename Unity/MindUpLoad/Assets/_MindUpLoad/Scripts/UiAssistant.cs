using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiAssistant : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter;

    public TextMeshProUGUI messageText;


    // Start is called before the first frame update
    private void Start()
    {
      
        textWriter.AddWriter(messageText, messageText.text, .1f);
    }
    
}

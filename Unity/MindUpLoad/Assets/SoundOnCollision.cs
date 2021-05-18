using UnityEngine;
using System.Collections;


public class SoundOnCollision : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
        Debug.Log("Object Entered the trigger");
    }

}

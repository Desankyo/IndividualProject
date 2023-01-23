using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    //Audio
    AudioSource audioManager;
    public AudioClip MenuSound;

    // Start is called before the first frame update
       void Start()
    {
        audioManager = GetComponent<AudioSource>(); 

        //Music
        audioManager.clip = MenuSound;
        audioManager.Play();
    }

    
}

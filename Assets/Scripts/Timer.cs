using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public TextMeshProUGUI TimerTxt;
    public GameObject WinTextObject;

    //Audio
    AudioSource audioManager;
    public AudioClip bgMuse;
    public AudioClip WinClip;

    private Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;

        WinTextObject.SetActive(false);

        audioManager = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerOn)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;

                WinTextObject.SetActive(true);

                //For sound
                audioManager.clip = bgMuse;
                audioManager.Stop();
                audioManager.clip = WinClip;
                audioManager.Play();

                
            }
        }
    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

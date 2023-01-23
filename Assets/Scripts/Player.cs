using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public Rigidbody2D player;

    private bool gameOver = false;

    //Audio
    AudioSource audioManager;
    public AudioClip bgMuse;
    public AudioClip WinClip;
    public AudioClip LoseClip;

    //Text
    public GameObject WinTextObject;
    public GameObject LoseTextObject;

    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<Rigidbody2D>();
        audioManager = GetComponent<AudioSource>();

        //Music
        audioManager.clip = bgMuse;
        audioManager.Play();

        //Text
        WinTextObject.SetActive(false);

        LoseTextObject.SetActive(false);
    }

    // Sound Effects
    public void PlaySound(AudioClip clip)
    {
        audioManager.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        // To close the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        // Restart
        if (Input.GetKey(KeyCode.R))
        {
            if (gameOver == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // this loads the currently active scene
            }
        }
    }

    void FixedUpdate()
    {
        MovePlayer ();
    }

    public void MovePlayer()
    {
        player.velocity = new Vector2(Input.GetAxis ("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;
    }

    //lose
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GetComponent<Player>().enabled = false;

            LoseTextObject.SetActive(true);

            //For sound
            audioManager.clip = bgMuse;
            audioManager.Stop();
            audioManager.clip = LoseClip;
            audioManager.Play();

            gameOver = true;
        }

        if (collision.collider.tag == "Eprojectile")
        {
            LoseTextObject.SetActive(true);

            //For sound
            audioManager.clip = bgMuse;
            audioManager.Stop();
            audioManager.clip = LoseClip;
            audioManager.Play();

            gameOver = true;
        }
    }
}

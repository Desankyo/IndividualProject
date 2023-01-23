using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveProjectile : MonoBehaviour
{
    public Rigidbody2D projectile;
    public float moveSpeed = 10.0f;

    //Audio
    AudioSource audioManager;
    public AudioClip bgMuse;
    public AudioClip WinClip;

    //Text
    public GameObject WinTextObject;

    // Start is called before the first frame update
    void Start()
    {
        projectile = this.gameObject.GetComponent<Rigidbody2D> ();

        audioManager = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        projectile.velocity = new Vector2(0, 1) * moveSpeed;

        //Text
        WinTextObject.SetActive(false);
    }

    public void PlaySound(AudioClip clip)
    {
        audioManager.PlayOneShot(clip);
    }

    //Hit detection
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            WinTextObject.SetActive(true);
            collision.gameObject.SetActive (false);
        }

        if(collision.gameObject.name == "TopWall")
        {
            Object.Destroy (this.gameObject);
        }
    }
}

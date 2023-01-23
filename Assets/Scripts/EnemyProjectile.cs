using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyProjectile : MonoBehaviour
{
    public Rigidbody2D projectile;
    public float moveSpeed = 15.0f;

    //Audio
    AudioSource audioManager;
    public AudioClip bgMuse;
    public AudioClip LoseClip;

    //Text
    public GameObject LoseTextObject;

    // Start is called before the first frame update
    void Start()
    {
        projectile = this.gameObject.GetComponent<Rigidbody2D>();

        //Text
        LoseTextObject.SetActive(false);

        audioManager = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        projectile.velocity = new Vector2(0, -1) * moveSpeed;
    }

    //Hit Detection
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            LoseTextObject.SetActive(true);
            collision.gameObject.SetActive (false);
        }

        if(collision.gameObject.name == "BottomWall")
        {
            Object.Destroy (this.gameObject);
        }
    }
}

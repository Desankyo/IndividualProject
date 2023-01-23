using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D enemy;
    public float moveSpeed = 15.0f;
    public bool changeDirection = false;

    AudioSource audioManager;
    public AudioClip Beam;
    public AudioClip WinClip;

    //Text
    public GameObject WinTextObject;

    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject.GetComponent<Rigidbody2D> (); 

        WinTextObject.SetActive(false);

        audioManager = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemy ();
    }

    public void moveEnemy()
    {
        if (changeDirection == true)
        {
            enemy.velocity = new Vector2(1,0) * -1 * moveSpeed;
        }
        else if (changeDirection == false)
        {
            enemy.velocity = new Vector2(1,0) * moveSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "RightWall")
        {
            changeDirection = true;
        }
        if(collision.gameObject.name == "LeftWall")
        {
            changeDirection = false;
        }


        if (collision.collider.tag == "Pprojectile")
        {
            WinTextObject.SetActive(true);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform projectileSpawn;
    public GameObject projectile;
    public float nextFire = 1.0f;
    public float currentTime = 0.0f;

    // Audio
    AudioSource audioManager;
    public AudioClip beamSound;


    // Start is called before the first frame update
    void Start()
    {
        projectileSpawn = this.gameObject.transform;

        audioManager = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        shoot ();
    }

    public void PlaySound(AudioClip clip)
    {
        audioManager.PlayOneShot(clip);
    }

    public void shoot()
    {
        currentTime += Time.deltaTime;

        if(Input.GetButton("Fire1") && currentTime > nextFire)
        {
            nextFire += currentTime;
            //creates the projectile
            Instantiate(projectile, projectileSpawn.position, Quaternion.identity);

            nextFire -= currentTime;
            currentTime = 0.0f;

            audioManager.PlayOneShot(beamSound);
        }
    }
}

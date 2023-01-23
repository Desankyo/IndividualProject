using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectileSpawn;
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
        enemyShoot ();
    }

    public void PlaySound(AudioClip clip)
    {
        audioManager.PlayOneShot(clip);
    }

    public void enemyShoot()
    {
        currentTime += Time.deltaTime;

        if(currentTime > nextFire)
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

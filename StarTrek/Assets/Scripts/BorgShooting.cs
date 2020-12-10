using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorgShooting : MonoBehaviour
{
    [Header("Shoooting Parameters")]
    [SerializeField] float minTimeBetweenShots;
    [SerializeField] float maxTimeBetweenShots;
    float shotCounter;
    
    [Header("Projectiles")]
    [SerializeField] GameObject borgTorpedoPrefab;

    [Header("Sound Effects")]
    [SerializeField] AudioClip borgTorpedoSound;
    [SerializeField] float borgTorpedoVolume;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndFire();
    }

    private void CountDownAndFire()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject torpedo = Instantiate(borgTorpedoPrefab);
        torpedo.transform.position = transform.position + transform.forward;
        torpedo.transform.rotation = transform.rotation;
        AudioSource.PlayClipAtPoint(borgTorpedoSound, transform.position, borgTorpedoVolume);
    }
}

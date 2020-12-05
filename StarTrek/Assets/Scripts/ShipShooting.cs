using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{

    [Header("Projectiles")]
    [SerializeField] GameObject torpedoPrefab;
    
    [Header("Sound Effects")]
    [SerializeField] AudioClip torpedoSound;
    [SerializeField] float torpedoSoundVolume;



    // Update is called once per frame
    void Update()
    {
        Fire();
    }


    private void Fire()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject torpedo = Instantiate(torpedoPrefab);
            torpedo.transform.position = transform.position + transform.forward;
            torpedo.transform.rotation = transform.rotation;
            AudioSource.PlayClipAtPoint(torpedoSound, transform.position, torpedoSoundVolume);
        }
    }
}

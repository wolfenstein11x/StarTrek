using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorgShooting : MonoBehaviour
{
    [Header("Projectiles")]
    [SerializeField] GameObject borgTorpedoPrefab;

    [Header("Sound Effects")]
    [SerializeField] AudioClip borgTorpedoSound;
    [SerializeField] float borgTorpedoVolume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject torpedo = Instantiate(borgTorpedoPrefab);
            torpedo.transform.position = transform.position + transform.forward;
            torpedo.transform.rotation = transform.rotation;
            AudioSource.PlayClipAtPoint(borgTorpedoSound, transform.position, borgTorpedoVolume);
        }
    }
}

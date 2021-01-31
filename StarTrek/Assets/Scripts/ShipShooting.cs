using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{

    [SerializeField] GameObject[] guns;

    [Header("Sound Effects")]
    [SerializeField] AudioClip torpedoSound;
    [SerializeField] float torpedoSoundVolume;

    public float torpedoLoadTime = 5f;

    public bool torpedoReady = true;

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<ShipHealth>().isAlive) { return; }

        ProcessFiring();
    }


    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            print("shooting");
            SetGunsActive(true);
        }

        else
        {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;

        }
    }

}

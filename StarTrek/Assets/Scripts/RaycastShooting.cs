using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooting : MonoBehaviour
{
    public float fireRate = 0.25f;
    public float weaponRange = 50f;
    public Transform gunEnd;

    [SerializeField] Camera myCam;

    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private AudioSource laserAudio;
    private LineRenderer laserLine;
    private float nextFire;

    
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserAudio = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        // Check if the player has pressed the fire button and if enough time has elapsed since they last fired
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            // Update the time when our player can fire next
            nextFire = Time.time + fireRate;

            // Start our ShotEffect coroutine to turn our laser line on and off
            StartCoroutine(ShotEffect());

            // Create a vector at the center of our camera's viewport
            Vector3 rayOrigin = myCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            // Declare a raycast hit to store information about what our raycast has hit
            RaycastHit hit;

            // Set the start position for our visual effect for our laser to the position of gunEnd
            laserLine.SetPosition(0, gunEnd.position);

            // Check if our raycast has hit anything
            if (Physics.Raycast(rayOrigin, myCam.transform.forward, out hit, weaponRange))
            {
                // Set the end position for our laser line 
                laserLine.SetPosition(1, hit.point);

                Debug.Log("Hit!");
                Debug.Log(hit.collider);
            }

            else
            {
                // If we did not hit anything, set the end of the line to a position directly in front of the camera at the distance of weaponRange
                laserLine.SetPosition(1, rayOrigin + (myCam.transform.forward * weaponRange));
            }



        }
    }

    private IEnumerator ShotEffect()
    {
        laserAudio.Play();

        // Turn on our line renderer
        laserLine.enabled = true;

        //Wait for .07 seconds
        yield return shotDuration;

        // Deactivate our line renderer after waiting
        laserLine.enabled = false;
    }
}

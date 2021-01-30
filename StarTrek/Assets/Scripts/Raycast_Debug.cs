using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_Debug : MonoBehaviour
{
    // this script is just for debugging
    // this draws a line (in the scene view) to show where the ray is going

    public float weaponRange = 50f;

    [SerializeField] Camera myCam;

    void Start()
    {
       
    }


    void Update()
    {
        Vector3 lineOrigin = myCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(lineOrigin, myCam.transform.forward * weaponRange, Color.green);
    }
}

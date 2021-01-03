using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    float a;

    private void Start()
    {
        a = offset[2];
    }
    // Update is called once per frame
    void LateUpdate()
    {
        //if (!FindObjectOfType<ShipHealth>().isAlive) { return; }

        transform.position = (target.position + offset);
        transform.rotation = target.rotation;
    }
}

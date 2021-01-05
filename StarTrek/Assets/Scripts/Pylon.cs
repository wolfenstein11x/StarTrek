using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pylon : MonoBehaviour
{
    [SerializeField] GameObject collectVFX;
    [SerializeField] float explosionDuration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        GameObject flash = Instantiate(collectVFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(flash, explosionDuration);
    }
}

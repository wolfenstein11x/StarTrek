using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorgCannon : MonoBehaviour
{
    public Transform player;
    public float playerDistance;
    public float rotationDamping;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //playerDistance = Vector3.Distance(player.position, transform.position);
        //Debug.Log(playerDistance);
        Aim();
    }

    void Aim()
    {
        transform.LookAt(player);
        //Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationDamping * Time.deltaTime);
    }
}

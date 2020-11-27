using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorgMotion : MonoBehaviour
{
 
    [SerializeField] float rotateSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
    }
}

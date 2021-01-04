using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pylon_Tracker : MonoBehaviour
{
    [SerializeField] GameObject Vulnerability;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPylons();   
    }

    private void CheckPylons()
    { 
        if (GetComponentsInChildren<Pylon>().Length <= 0)
        {
            Vulnerability.SetActive(true);
        }
    }
}

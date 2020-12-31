using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 100;
    public float health;
    Slider mySlider;

    // Start is called before the first frame update
    void Start()
    {
        mySlider = GetComponent<Slider>();
        mySlider.value = 1.0f;
        health = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // make ProcessHit more flexible so it can process damage from other projectiles
    public void ProcessHit()    // give it an input parameter
    {
        health -= FindObjectOfType<BorgTorpedo>().damage;
        mySlider.value = health / startingHealth;
    }
}

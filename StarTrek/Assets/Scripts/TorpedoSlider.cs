using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorpedoSlider : MonoBehaviour
{
    Slider mySlider;
    public float rechargeSpeed = 0.002f;

    // Start is called before the first frame update
    void Start()
    {
        mySlider = GetComponent<Slider>();
        mySlider.value = 1f;
    }

    public void ResetSlider()
    {
        StartCoroutine(ResetSliderCoroutine());
    }

    IEnumerator ResetSliderCoroutine()
    {
        mySlider.value = 0;

        for (float val = 0.0f; val <= 1f; val += rechargeSpeed)
        {
            mySlider.value = val;
            yield return null;
        }

        FindObjectOfType<ShipShooting>().torpedoReady = true;
    }

    

    
}

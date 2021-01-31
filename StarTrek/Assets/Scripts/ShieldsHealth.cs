using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldsHealth : MonoBehaviour
{
    [SerializeField] Slider shieldsSlider;

    [SerializeField] int startingShields = 100;

    public float shields;

    // Start is called before the first frame update
    void Start()
    {
        shieldsSlider.value = 1.0f;

        shields = startingShields;
    }

    
    public void ProcessShieldsHit()    // give it an input parameter
    {
        shields -= FindObjectOfType<BorgTorpedo>().damage;
        shieldsSlider.value = shields / startingShields;

        if (shields <= 0f)
        {
            Destroy(gameObject);
        }
    }
}

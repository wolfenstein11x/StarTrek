using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorpedoSlider : MonoBehaviour
{
    Slider mySlider;

    // Start is called before the first frame update
    void Start()
    {
        mySlider = GetComponent<Slider>();
        mySlider.value = 1f;
    }

    public void ResetSlider()
    {
        StartCoroutine(ResetSliderCoroutine());
        //mySlider.value = 0f;
    }

    IEnumerator ResetSliderCoroutine()
    {
        for (float val = 1.0f; val >= 0f; val -= 0.02f)
        {
            mySlider.value = val;
            yield return null;
        }
    }

    public void ChargeSlider()
    {
        mySlider.value = 1f;
    }

    // finish ChargeSlider coroutine
    IEnumerator ChargeSliderCoroutine()
    {
        yield return null;
    }
}

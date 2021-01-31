using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldsHealth : MonoBehaviour
{
    [SerializeField] Slider shieldsSlider;

    [SerializeField] int startingShields = 100;

    public float shields;
    private MeshRenderer shieldsMesh;


    // Start is called before the first frame update
    void Start()
    {
        shieldsMesh = GetComponent<MeshRenderer>();
        HideShields();

        shieldsSlider.value = 1.0f;

        shields = startingShields;
    }

    private void HideShields()
    {
        shieldsMesh.enabled = false;
    }

    IEnumerator ShowShields()
    {
        shieldsMesh.enabled = true;

        yield return new WaitForSeconds(0.1f);

        HideShields();
    }
   

    
    public void ProcessShieldsHit()    // give it an input parameter
    {
        StartCoroutine(ShowShields());
        shields -= FindObjectOfType<BorgTorpedo>().damage;
        shieldsSlider.value = shields / startingShields;

        if (shields <= 0f)
        {
            Destroy(gameObject);
        }
    }
}

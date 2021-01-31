using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipHealth : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    

    [SerializeField] GameObject DeathExplosion;
    [SerializeField] AudioClip DeathExplosionSound;
    [SerializeField] [Range(0, 1)] float deathExplosionVolume;
    public float deathExplosionDuration = 2f;

    [SerializeField] int startingHealth = 100;
    
    public float health;
    

    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = 1.0f;
        
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
        healthSlider.value = health / startingHealth;

        if (health <= 0f)
        {
            ProcessPlayerDeath();
        }
    }

    



    private void ProcessPlayerDeath()
    {
        isAlive = false;
        GameObject DeathVFX = Instantiate(DeathExplosion, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(DeathExplosionSound, transform.position, deathExplosionVolume);
        Destroy(DeathVFX, deathExplosionDuration);

        FindObjectOfType<SceneLoader>().LoadLoseMenu();
    }
}

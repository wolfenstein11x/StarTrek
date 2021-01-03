using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipHealth : MonoBehaviour
{
    [SerializeField] GameObject Player;

    [SerializeField] GameObject DeathExplosion;
    [SerializeField] AudioClip DeathExplosionSound;
    [SerializeField] [Range(0, 1)] float deathExplosionVolume;
    public float deathExplosionDuration = 2f;

    [SerializeField] int startingHealth = 100;
    public float health;

    Slider mySlider;

    public bool isAlive = true;

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

        if (health <= 0f)
        {
            ProcessPlayerDeath();
        }
    }

    private void ProcessPlayerDeath()
    {
        isAlive = false;
        GameObject DeathVFX = Instantiate(DeathExplosion, Player.transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(DeathExplosionSound, Player.transform.position, deathExplosionVolume);
        Destroy(DeathVFX, deathExplosionDuration);

        FindObjectOfType<SceneLoader>().LoadLoseMenu();
    }
}

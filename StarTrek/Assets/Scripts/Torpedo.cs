﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    [Header("Visual Effects")]
    [SerializeField] GameObject hitVFX;
    [SerializeField] float explosionDuration;

    [Header("Sound Effects")]
    [SerializeField] AudioClip hitSound;
    [SerializeField] [Range(0, 1)] float hitSoundVolume = 0.7f;

    public float torpedoSpeed = 8f;
    public float lifeDuration = 5f;

    private float lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = lifeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * torpedoSpeed * Time.deltaTime;
        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        GameObject boom = Instantiate(hitVFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(boom, explosionDuration);
        AudioSource.PlayClipAtPoint(hitSound, transform.position, hitSoundVolume);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    AudioSource loadMenuAudioSource;
    int currentSceneIndex;
    int winSceneIndex = 3;
    int loseSceneIndex = 2;

    void Start()
    {
        DontDestroyOnLoad(this);
        loadMenuAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        if (currentSceneIndex == winSceneIndex || currentSceneIndex == loseSceneIndex)
        {
            loadMenuAudioSource.volume = 0;
        }
    }
}

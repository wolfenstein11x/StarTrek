using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int loseWaitTime = 3;
    public int winWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start_Menu");
    }

    public void LoadLoseMenu()
    {
        StartCoroutine(LoadLoseMenuCoroutine());
    }

    IEnumerator LoadLoseMenuCoroutine()
    {
        yield return new WaitForSeconds(loseWaitTime);
        SceneManager.LoadScene("Lose_Menu");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}

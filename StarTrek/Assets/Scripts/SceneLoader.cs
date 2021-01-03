using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int loseWaitTime = 3;
    public int winWaitTime = 3;

    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        // if you are in the Game scene and all the borg are destroyed, go to the win scene
        if (currentSceneIndex == 1 && FindObjectsOfType<Borg>().Length == 0)
        {
            LoadWinMenu();
        }
           
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

    private void LoadWinMenu()
    {
        StartCoroutine(LoadWinMenuCoroutine());
    }

    IEnumerator LoadWinMenuCoroutine()
    {
        yield return new WaitForSeconds(winWaitTime);
        SceneManager.LoadScene("Win_Menu");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}

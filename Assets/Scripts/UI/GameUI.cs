using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameUI : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public GameObject UIBar;
    public GameObject GameOverScreen;
    public GameObject LevelCompleteScreen;

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        UIBar.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        UIBar.SetActive(false);

        //TODO: Pause Game

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void openGameOverScreen()
    {
        GameOverScreen.SetActive(true);
        UIBar.SetActive(false);

        //TODO: Pause Game

    }

    public IEnumerator LevelCompleted()
    {
        LevelCompleteScreen.SetActive(true);

        yield return new WaitForSeconds(2f);

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

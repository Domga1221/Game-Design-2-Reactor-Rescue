using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public GameObject UIBar;

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        UIBar.SetActive(true);
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        UIBar.SetActive(false);
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
}

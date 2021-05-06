using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Animator playTransition;
    public void PlayGame(int levelIndex)
    {
        StartCoroutine(LoadGame(levelIndex));
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    IEnumerator LoadGame(int levelIndex)
    {
        playTransition.SetTrigger("StartGame");

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + levelIndex);
    }
}
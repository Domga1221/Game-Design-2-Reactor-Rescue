using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Animator playTransition;
    public void PlayGame()
    {
        StartCoroutine(LoadGame());
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    IEnumerator LoadGame()
    {
        playTransition.SetTrigger("StartGame");

        yield return new WaitForSeconds(1.75f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIBar : MonoBehaviour
{
    public PlayerMovementToBeat Player;
    public TMP_Text Collected;
    public TMP_Text NumberOfCollectables;
    public TMP_Text Level;

    void Update()
    {
        NumberOfCollectables.text = "/" + Player.numberOfCollectibles.ToString();
        Collected.text = Player.score.ToString();
        Level.text = "Level " + SceneManager.GetActiveScene().buildIndex.ToString();
    }
}

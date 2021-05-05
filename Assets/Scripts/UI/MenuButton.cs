using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text buttonText;

    public void Start()
    {
        buttonText.color = Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = new Color32(47, 48, 63, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = Color.white; 
    }

    public void ResetButtonColor()
    {
        buttonText.color = Color.white;
    }

}
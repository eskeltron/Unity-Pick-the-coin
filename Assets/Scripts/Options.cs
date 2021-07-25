using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Options : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Color textColorSelected = new Color(180, 180, 180, 0.5f);
    public Color textColorDeselected = new Color(67, 67, 67,100);

    public GameObject text;

    public void OnPointerClick(PointerEventData eventData)
    {
        text.GetComponent<Text>().color = textColorDeselected;
        GetComponent<Image>().color = new Color(0, 0, 0, 0);
        this.GetComponent<Selectable>().OnPointerExit(null);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!EventSystem.current.alreadySelecting)
        {
            text.GetComponent<Text>().color = textColorSelected;
            GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
            EventSystem.current.SetSelectedGameObject(this.gameObject);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        text.GetComponent<Text>().color = textColorDeselected;
        GetComponent<Image>().color = new Color(0, 0, 0, 0);
        this.GetComponent<Selectable>().OnPointerExit(null);
    }
}

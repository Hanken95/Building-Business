using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public Sprite idleSprite;
    public Sprite hoverSprite;
    public Sprite activeSprite;
    public GameObject optionsMenu;

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = hoverSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = activeSprite;
        optionsMenu.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = idleSprite;
    }

    void Start()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PurchaseButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public Color buttonIdle;
    public Color buttonHover;
    public Color buttonActive;

    internal Image background;

    void Start()
    {
        background = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        background.color = buttonActive;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        background.color = buttonHover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        background.color = buttonIdle;
        var uIManager = FindObjectOfType<UIManager>();
        uIManager.PlaceBuilding();

    }
}

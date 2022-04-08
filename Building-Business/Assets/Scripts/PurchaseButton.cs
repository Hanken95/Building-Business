using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PurchaseButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    Player player;
    private UIManager uIMAnager;
    public Color buttonIdle;
    public Color buttonHover;
    public GameObject unableToPurchaseButton;

    internal Image background;

    void Start()
    {
        background = GetComponent<Image>();
        player = FindObjectOfType<Player>();
        uIMAnager = FindObjectOfType<UIManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (player.Money >= uIMAnager.objectToPurchase.cost)
        {
            background.color = buttonIdle;
            uIMAnager.PlaceBuilding();
        }
        else
        {
            DisplayUnableToPurchaseButton();
        }
    }

    private void DisplayUnableToPurchaseButton()
    {
        unableToPurchaseButton.SetActive(true);
        Invoke("DisableUnableToPurchaseButton", 1.6f);
    }

    private void DisableUnableToPurchaseButton()
    {
        unableToPurchaseButton.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        background.color = buttonHover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        background.color = buttonIdle;
    }
}

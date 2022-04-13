using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PurchaseButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    private Player player;
    private UIManager uIManager;

    public Color buttonIdle;
    public Color buttonHover;
    
    internal Image background;

    void Start()
    {
        background = GetComponent<Image>();
        player = FindObjectOfType<Player>();
        uIManager = FindObjectOfType<UIManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int cost = uIManager.objectToPurchase.cost;
        if (player.money >= cost)
        {
            background.color = buttonIdle;
            if (uIManager.objectToPurchase is Building)
            {
                uIManager.PlaceBuilding();
            }
            else if (uIManager.objectToPurchase.GetType() == typeof(Person))
            {
                uIManager.HireEmployee();
            }
            else
            {
                if (!uIManager.unableToPurchaseButton.activeSelf)
                {
                    uIManager.DisplayUnableToPurchaseButton();
                }
                return;
            }
            player.money -= cost;
            uIManager.UpdateUIMoney();
        }
        else
        {
            if (!uIManager.unableToPurchaseButton.activeSelf)
            {
                uIManager.DisplayUnableToPurchaseButton();
            }
        }

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

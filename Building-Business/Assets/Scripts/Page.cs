using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    public List<PageButton> pageButtons = new List<PageButton>();

    public Color buttonIdle;
    public Color buttonHover;
    public Color buttonActive;
    PageButton selectedButton; 
    public GameObject purchaseButton;


    internal void Subscribe(PageButton pageButton)
    {
        pageButtons.Add(pageButton);
    }

    internal void OnButtonEnter(PageButton pageButton)
    {
        ResetButtons();
        if (selectedButton == null || pageButton != selectedButton)
        {
            pageButton.background.color = buttonHover;
        }
    }

    internal void OnButtonSelected(PageButton pageButton)
    {
        if (selectedButton == null || selectedButton != pageButton)
        {
            selectedButton = pageButton;
            ResetButtons();
            pageButton.background.color = buttonActive;
            purchaseButton.SetActive(true);
            var uIManager = FindObjectOfType<UIManager>();
                uIManager.objectToPurchase = pageButton.objectToPurchase;
        }
        else
        {
            selectedButton = null;
            purchaseButton.SetActive(false);
        }
    }

    internal void OnButtonExit()
    {
        ResetButtons();
    }

    public void ResetButtons()
    {
        foreach (PageButton pageButton in pageButtons)
        {
            if (selectedButton != null && pageButton == selectedButton)
            {
                continue;
            }
            pageButton.background.color = buttonIdle;
        }
    }
}

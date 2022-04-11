using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    public List<ItemButton> itemButtons = new List<ItemButton>();

    public Color buttonIdle;
    public Color buttonHover;
    public Color buttonActive;
    ItemButton selectedButton;

    UIManager uIManager;

    private void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
    }


    public void Subscribe(ItemButton itemButton)
    {
        itemButtons.Add(itemButton);
    }

    public void OnButtonEnter(ItemButton itemButton)
    {
        ResetNonSelectedButtons();
        if (selectedButton == null || itemButton != selectedButton)
        {
            itemButton.background.color = buttonHover;
        }
    }

    public void OnButtonSelected(ItemButton itemButton)
    {
        if (selectedButton == null || selectedButton != itemButton)
        {
            selectedButton = itemButton;
            ResetNonSelectedButtons();
            itemButton.background.color = buttonActive;
            uIManager.EnablePurchaseButton();
            uIManager.objectToPurchase = itemButton.objectToPurchase.GetComponent<PurchaseAbleItem>();
        }
        else
        {
            selectedButton = null;
            uIManager.DisablePurchaseButton();
        }
    }

    public void OnButtonExit()
    {
        ResetNonSelectedButtons();
    }

    public void ClearAllButtons()
    {
        selectedButton = null;
        foreach (ItemButton itemButton in itemButtons)
        {
            itemButton.background.color = buttonIdle;
        }
    }

    private void ResetNonSelectedButtons()
    {
        foreach (ItemButton itemButton in itemButtons)
        {
            if (selectedButton != null && itemButton == selectedButton)
            {
                continue;
            }
            itemButton.background.color = buttonIdle;
        }
    }
}

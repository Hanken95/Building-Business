using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageWithItemButtons : Page
{
    internal List<ItemButton> itemButtons = new List<ItemButton>();

    public Color buttonIdle;
    public Color buttonHover;
    public Color buttonActive;
    ItemButton selectedButton;

    protected UIManager uIManager;

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
            SelectUnselectedItemButton(itemButton);
        }
        else
        {
            DeselectItemButton();
        }
    }

    protected virtual void DeselectItemButton()
    {
        selectedButton = null;
    }

    protected virtual void SelectUnselectedItemButton(ItemButton itemButton)
    {
        selectedButton = itemButton;
        ResetNonSelectedButtons();
        itemButton.background.color = buttonActive;
        
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
            try
            {
                itemButton.background.color = buttonIdle;
            }
            catch (Exception)
            {
                Debug.Log("No background or something");
            }
            
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

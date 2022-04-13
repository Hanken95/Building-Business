using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    internal List<TabButton> tabButtons = new List<TabButton>();

    public Color tabIdle;
    public Color tabHover;
    public Color tabActive;
    public List<GameObject> pages = new List<GameObject>();
    public TabButton defaultTabButton;
    private TabButton selectedTabButton;
    private UIManager uIManager;

    private void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        ResetTabsAndPagesToDefault();
    }

    public void Subscribe(TabButton tabButton)
    {
        tabButtons.Add(tabButton);
    }

    public void OnTabEnter(TabButton tabButton)
    {
        ResetNonSelectedTabs();
        if (selectedTabButton == null || tabButton != selectedTabButton)
        {
            tabButton.background.color = tabHover;
        }
    }

    public void OnTabSelected(TabButton tabBbutton)
    {
        if (selectedTabButton != tabBbutton)
        {
            selectedTabButton = tabBbutton;
            ResetNonSelectedTabs();
            uIManager.DisablePurchaseButton();
            tabBbutton.background.color = tabActive;
            int index = tabBbutton.transform.GetSiblingIndex();

            for (int i = 0; i < pages.Count; i++)
            {
                if (i == index)
                {
                    pages[i].SetActive(true);
                    uIManager.activePage = pages[i].GetComponent<PageWithItemButtons>();
                }
                else
                {
                    var pageScript = pages[i].GetComponent<PageWithItemButtons>();
                    if (pageScript != null)
                    {
                        pageScript.ClearAllButtons();
                    }
                    pages[i].SetActive(false);
                }
            }
        }
    }

    public void OnTabExit()
    {
        ResetNonSelectedTabs();
    }

    public void ResetNonSelectedTabs()
    {
        foreach (TabButton tabButton in tabButtons)
        {
            if (selectedTabButton != null && tabButton == selectedTabButton)
            {
                continue;
            }
            tabButton.background.color = tabIdle;
        }
    }
    public void ResetTabsAndPagesToDefault()
    {
        OnTabSelected(defaultTabButton);
    }

}

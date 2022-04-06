using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons = new List<TabButton>();

    public Color tabIdle;
    public Color tabHover;
    public Color tabActive;
    public TabButton selectedTab;
    public List<GameObject> objectsToSwap;

    public void Subscribe(TabButton button)
    {
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.color = tabHover;
        }
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        var test= button.GetComponentInChildren<Image>();
        button.background.color = tabActive;
        int index = button.transform.GetSiblingIndex();

        for (int i = 0; i < objectsToSwap.Count; i++)
        {
            if (i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }
    }

    public void OnTabExit()
    {
        ResetTabs();
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab)
            {
                continue;
            }
            button.background.color = tabIdle;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AbleToClick
{
    All,
    UI
}

public enum ActiveMenu
{
    None,
    Build,
    BuildingInfo
}

public class UIManager : MonoBehaviour
{
    public Text moneyText;
    public Text incomeText;
    public Text praiseText;
    public Text complaintsText;

    public GameObject buildMenu;
    public GameObject buildingInfoMenu;

    public GameObject purchaseButton;
    public GameObject hireButton;
    public GameObject fireButton;
    public GameObject unableToPurchaseButton;
    public List<Page> buildMenuPages;
    public List<Page> buildingInfoMenuPages;

    private TabGroup buildMenuTabGroup;
    private TabGroup buildingInfoMenuTabGroup;
    private GameManager gameManager;
    private GameObject chosenTile;
    private Player player;

    internal PurchaseAbleItem objectToPurchase;
    internal Workplace selectedWorkplace;
    internal PageWithItemButtons activePage;

    public AbleToClick AbleToClick { get; private set; }

    private ActiveMenu activeMenu = ActiveMenu.None;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        InvokeRepeating("UpdateUIContinuously", 0.1f, GameManager.gameTickTime);
    }

    public void UpdatePraise()
    {
        praiseText.text = "Praise: " + player.TotalPraise;
    }

    public void UpdateComplaints()
    {
        complaintsText.text = "Complaints: " + player.TotalComplaints;
    }

    public void UpdateUIMoney()
    {
        moneyText.text = "Money: " + FindObjectOfType<Player>().money.ToString() + "€";
        incomeText.text = "Income: " + FindObjectOfType<Player>().income.ToString() + "€";
    }

    private void UpdateUIContinuously()
    {
        if (!GameManager.GamePaused)
        {
            UpdateUIMoney();
            UpdatePraise();
            UpdateComplaints();
        }
    }

    public void PlaceBuilding()
    {
        var localTransform = chosenTile.transform.GetChild(0);
        objectToPurchase.transform.localScale = localTransform.localScale;
        if (objectToPurchase.GetType() == typeof(Office))
        {
            Instantiate(objectToPurchase.gameObject, localTransform.position,
                localTransform.rotation, chosenTile.transform);
        }
        else
        {
            Instantiate(objectToPurchase.gameObject, chosenTile.transform);
        }
        chosenTile.GetComponent<MeshRenderer>().enabled = false;
        chosenTile.GetComponent<BoxCollider>().enabled = false;

        CloseActiveMenu();
    }

    internal void HireEmployee()
    {
        //selectedWorkplace.Hire((Person)objectToPurchase);
    }

    internal void CloseActiveMenu()
    {
        switch (activeMenu)
        {
            case ActiveMenu.Build:
                CloseBuildMenu();
                break;
            case ActiveMenu.BuildingInfo:
                CloseBuildingInfoMenu();
                break;
        }
        activeMenu = ActiveMenu.None;
        AbleToClick = AbleToClick.All;
    }

    public void OpenBuildMenu(GameObject tileToBuildOn)
    {
        activeMenu = ActiveMenu.Build;
        chosenTile = tileToBuildOn;
        gameManager.PauseGame();
        AbleToClick = AbleToClick.UI;
        buildMenu.SetActive(true);
        if (buildMenuTabGroup == null)
        {
            buildMenuTabGroup = FindObjectOfType<TabGroup>();
        }
    }

    private void CloseBuildMenu()
    {
        buildMenuTabGroup.ResetTabsAndPagesToDefault();
        buildMenu.SetActive(false);
        DisablePurchaseButton();

        activePage.ClearAllButtons();
        
        objectToPurchase = null;
        gameManager.ResumeGame();
    }

    public void OpenBuildingInfoMenu(GameObject chosenBuilding)
    {
        gameManager.PauseGame();
        selectedWorkplace = chosenBuilding.GetComponent<Workplace>();
        buildingInfoMenu.SetActive(true);
        if (buildingInfoMenuTabGroup == null)
        {
            buildingInfoMenuTabGroup = FindObjectOfType<TabGroup>();
        }
        activeMenu = ActiveMenu.BuildingInfo;
        AbleToClick = AbleToClick.UI;
    }

    private void CloseBuildingInfoMenu()
    {
        buildingInfoMenuTabGroup.ResetTabsAndPagesToDefault();
        buildingInfoMenu.SetActive(false);
        
        selectedWorkplace = null;
        gameManager.ResumeGame();
    }

    public void EnablePurchaseButton()
    {
        purchaseButton.SetActive(true);
    }

    public void DisablePurchaseButton()
    {
        purchaseButton.SetActive(false);
    }

    public void EnableHireButton()
    {
        hireButton.SetActive(true);
    }

    public void DisableHireButton()
    {
        hireButton.SetActive(false);
    }

    public void EnableFireButton()
    {
        fireButton.SetActive(true);
    }

    public void DisableFireButton()
    {
        fireButton.SetActive(false);
    }

    public void DisplayUnableToPurchaseButton()
    {
        if (IsInvoking("DisableUnableToPurchaseButton"))
        {
            CancelInvoke("DisableUnableToPurchaseButton");
        }
        if (!unableToPurchaseButton.activeSelf)
        {
            unableToPurchaseButton.SetActive(true);
            Invoke("DisableUnableToPurchaseButton", 1.6f);
        }
    }

    public void DisableUnableToPurchaseButton()
    {
        if (unableToPurchaseButton.activeSelf)
        {
            unableToPurchaseButton.SetActive(false);
        }
    }
}

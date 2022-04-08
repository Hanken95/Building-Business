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

public class UIManager : MonoBehaviour
{
    public Text moneyText;
    public Text incomeText;
    public GameObject buildMenu;
    public GameObject purchaseButton;
    public GameObject unableToPurchaseButton;
    public List<Page> pages;

    private TabGroup tabGroup;
    private GameManager gameManager;
    private GameObject chosenTile;

    internal PurchaseAbleItem objectToPurchase;

    internal AbleToClick AbleToClick { get; private set; }

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        InvokeRepeating("UpdateUIMoneyContinuously", 0, 3);
    }

    public void UpdateUIMoney()
    {
        moneyText.text = "Money: " + FindObjectOfType<Player>().money.ToString() + "€";
        incomeText.text = "Income: " + FindObjectOfType<Player>().income.ToString() + "€";
    }
    private void UpdateUIMoneyContinuously()
    {
        if (!gameManager.GamePaused)
        {
            UpdateUIMoney();
        }
    }


    public void PlaceBuilding()
    {
        var buildingPlacement = chosenTile.transform.GetChild(0);

        objectToPurchase.transform.localScale = buildingPlacement.localScale;

        Instantiate(objectToPurchase, buildingPlacement.position,
            buildingPlacement.rotation, chosenTile.transform);

        CloseBuildingsMenu();
    }

    internal void OpenBuildMenu(GameObject tileToBuildOn)
    {
        chosenTile = tileToBuildOn;
        gameManager.PauseGame();
        AbleToClick = AbleToClick.UI;
        buildMenu.SetActive(true);
        if (tabGroup == null)
        {
            tabGroup = FindObjectOfType<TabGroup>();
        }
    }

    internal void CloseBuildingsMenu()
    {
        gameManager.ResumeGame();
        AbleToClick = AbleToClick.All;
        tabGroup.ResetAllTabsAndPageContent();
        buildMenu.SetActive(false);
        DisablePurchaseButton();

        foreach (Page page in pages)
        {
            page.ClearAllButtons();
        }

        objectToPurchase = null;
    }

    internal void OpenBuildingInfo(GameObject chosenBuilding)
    {
        gameManager.PauseGame();
    }

    internal void EnablePurchaseButton()
    {
        purchaseButton.SetActive(true);
    }
    internal void DisablePurchaseButton()
    {
        purchaseButton.SetActive(false);
    }

    public void DisplayUnableToPurchaseButton()
    {
        unableToPurchaseButton.SetActive(true);
        Invoke("DisableUnableToPurchaseButton", 1.6f);
    }

    public void DisableUnableToPurchaseButton()
    {
        unableToPurchaseButton.SetActive(false);
    }

}

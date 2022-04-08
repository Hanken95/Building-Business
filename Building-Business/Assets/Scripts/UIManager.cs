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
    public GameObject buildMenu;
    public GameObject purchaseButton;
    public List<Page> pages;

    private TabGroup tabGroup;
    private GameManager gameManager;
    private GameObject chosenTile;

    internal PurchaseAbleItem objectToPurchase;

    internal AbleToClick AbleToClick { get; private set; }

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        InvokeRepeating("UpdateUIMoney", 0, 1);
    }

    private void UpdateUIMoney()
    {
        if (!gameManager.GamePaused)
        {
            moneyText.text = "Money: " + FindObjectOfType<Player>().Money.ToString() + "€";
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

}

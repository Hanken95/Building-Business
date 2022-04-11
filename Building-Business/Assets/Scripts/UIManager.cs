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
    public Text praiseText;
    public Text complaintsText;
    public GameObject buildMenu;
    public GameObject purchaseButton;
    public GameObject unableToPurchaseButton;
    public List<Page> pages;

    private TabGroup tabGroup;
    private GameManager gameManager;
    private GameObject chosenTile;
    private Player player;

    public PurchaseAbleItem objectToPurchase;

    public AbleToClick AbleToClick { get; private set; }

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
        moneyText.text = "Money: " + FindObjectOfType<Player>().money.ToString() + "�";
        incomeText.text = "Income: " + FindObjectOfType<Player>().income.ToString() + "�";
    }
    private void UpdateUIContinuously()
    {
        if (!gameManager.GamePaused)
        {
            UpdateUIMoney();
            UpdatePraise();
            UpdateComplaints();
        }
    }


    public void PlaceBuilding()
    {
        if (objectToPurchase.GetType() == typeof(Office))
        {
            var buildingPlacement = chosenTile.transform.GetChild(0);

            Instantiate(objectToPurchase, buildingPlacement.position,
                buildingPlacement.rotation, chosenTile.transform);
        }
        else
        {
            Instantiate(objectToPurchase, chosenTile.transform);
        }
        chosenTile.GetComponent<MeshRenderer>().enabled = false;
        chosenTile.GetComponent<BoxCollider>().enabled = false;

        CloseBuildingsMenu();
    }

    public void OpenBuildMenu(GameObject tileToBuildOn)
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

    public void CloseBuildingsMenu()
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

    public void OpenBuildingInfo(GameObject chosenBuilding)
    {
        gameManager.PauseGame();
    }

    public void EnablePurchaseButton()
    {
        purchaseButton.SetActive(true);
    }
    public void DisablePurchaseButton()
    {
        purchaseButton.SetActive(false);
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

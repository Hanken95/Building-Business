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
    public GameObject buildingInfoMenu;

    public GameObject purchaseButton;
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
        moneyText.text = "Money: " + FindObjectOfType<Player>().money.ToString() + "€";
        incomeText.text = "Income: " + FindObjectOfType<Player>().income.ToString() + "€";
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
        var localTransform = chosenTile.transform.GetChild(0);
        objectToPurchase.transform.localScale = localTransform.localScale;
        if (objectToPurchase.GetType() == typeof(Office))
        {

            Instantiate(objectToPurchase, localTransform.position,
                localTransform.rotation, chosenTile.transform);
        }
        else
        {
            Instantiate(objectToPurchase, chosenTile.transform);
        }
        chosenTile.GetComponent<MeshRenderer>().enabled = false;
        chosenTile.GetComponent<BoxCollider>().enabled = false;

        CloseBuildMenu();
    }

    internal void HireEmployee()
    {
        //selectedWorkplace.Hire((Person)objectToPurchase);
    }

    internal void CloseMenus()
    {
        CloseBuildMenu();
        CloseBuildingInfoMenu();
    }


    public void OpenBuildMenu(GameObject tileToBuildOn)
    {
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
        AbleToClick = AbleToClick.All;
        buildMenuTabGroup.ResetTabsAndPagesToDefault();
        buildMenu.SetActive(false);
        DisablePurchaseButton();

        foreach (Page page in buildMenuPages)
        {
            page.ClearAllButtons();
        }

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
    }
    private void CloseBuildingInfoMenu()
    {
        buildingInfoMenuTabGroup.ResetTabsAndPagesToDefault();
        buildingInfoMenu.SetActive(false);

        foreach (Page page in buildingInfoMenuPages)
        {
            page.ClearAllButtons();
        }

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

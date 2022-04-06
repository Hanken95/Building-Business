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
    public GameObject buildingsMenu;

    private GameManager gameManager;
    private GameObject chosenTile;

    internal GameObject objectToPurchase;

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
            moneyText.text = "Money: " + FindObjectOfType<Player>().Money.ToString();
        }
    }

    public void PlaceBuilding()
    {
        objectToPurchase.transform.localScale = Vector3.one;

        var buildingPlacement = chosenTile.transform.GetChild(0);
        Instantiate(objectToPurchase, buildingPlacement.position,
            buildingPlacement.rotation, chosenTile.transform);
        CloseBuildingsMenu();
    }

    internal void OpenBuildingsMenu(GameObject tileToBuildOn)
    {
        chosenTile = tileToBuildOn;
        gameManager.PauseGame();
        AbleToClick = AbleToClick.UI;
        buildingsMenu.SetActive(true);
    }

    internal void CloseBuildingsMenu()
    {
        gameManager.ResumeGame();
        AbleToClick = AbleToClick.All;
        buildingsMenu.SetActive(false);
    }

    internal void OpenBuildingInfo(GameObject chosenBuilding)
    {
        gameManager.PauseGame();
    }
}

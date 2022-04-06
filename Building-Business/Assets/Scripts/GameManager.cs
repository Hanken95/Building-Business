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

public class GameManager : MonoBehaviour
{
    Player player = Player.player;
    public Text moneyText;
    public GameObject buildingsMenu;
    internal AbleToClick AbleToClick { get; private set; }

    public void ChangeMoney(int amount)
    {
        player.Money += amount;
        moneyText.text = "Money: " + player.Money;
    }

    internal void OpenBuildingsMenu(GameObject gameObject)
    {
        AbleToClick = AbleToClick.UI;
        buildingsMenu.SetActive(true);
    }

    internal void CloseBuildingsMenu()
    {
        AbleToClick = AbleToClick.All;
        buildingsMenu.SetActive(false);
    }
}

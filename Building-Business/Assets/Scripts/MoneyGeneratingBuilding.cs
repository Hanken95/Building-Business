using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGeneratingBuilding : PurchaseAbleItem
{
    internal int moneyGeneratedPerSecond = 5;

    void Awake()
    {
        FindObjectOfType<Player>().income += moneyGeneratedPerSecond;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGeneratingBuilding : PurchaseAbleItem
{
    internal int moneyGeneratedPerSecond = 5;

    internal virtual void Start()
    {
        FindObjectOfType<Player>().Income += moneyGeneratedPerSecond;
    }


}

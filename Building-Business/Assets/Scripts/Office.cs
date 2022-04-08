using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Office : MoneyGeneratingBuilding
{
    private Office()
    {
        moneyGeneratedPerSecond = 100;
        cost = 1000;
    }

    internal override void Start()
    {
        cost = 50;
        base.Start();
    }
}

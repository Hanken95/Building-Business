using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeText : InfoText
{
    private void Start()
    {
        SetText("Building Income: " + selectedWorkPlace.GetWorkplaceIncome().ToString() + "€");
    }
}

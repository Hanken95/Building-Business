using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeText : InfoText
{
    private void Start()
    {
        UpdateWorkPlaceIncome();
    }

    private void UpdateWorkPlaceIncome()
    {
        SetText("Building Income: " + selectedWorkPlace.GetWorkplaceIncome().ToString() + "€");
    }
}

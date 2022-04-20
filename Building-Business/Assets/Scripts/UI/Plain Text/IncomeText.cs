using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeText : InfoText
{
    public override void SetText()
    {
        SetSelectedWorkPlace();
        newText = "Building income: " + selectedWorkPlace.GetWorkplaceIncome().ToString() + "€";
        base.SetText();
    }
}

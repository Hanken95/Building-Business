using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessText : InfoText
{
    public override void SetText()
    {
        SetSelectedWorkPlace();
        newText = "Total Happiness: " + selectedWorkPlace.GetWorkplaceTotalHappiness().ToString();
        base.SetText();
    }
}

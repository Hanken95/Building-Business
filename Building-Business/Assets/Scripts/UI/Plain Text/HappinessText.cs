using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessText : InfoText
{
    private void Start()
    {
        SetText("Total Happiness: " + selectedWorkPlace.GetWorkplaceTotalHappiness().ToString());
    }
}

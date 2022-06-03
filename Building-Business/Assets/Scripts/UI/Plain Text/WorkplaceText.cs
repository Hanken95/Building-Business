using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkplaceText : InfoText
{
    public override void SetText()
    {
        SetSelectedWorkPlace();
        newText = "Name: " + selectedWorkPlace.name;
        base.SetText();
    }
}

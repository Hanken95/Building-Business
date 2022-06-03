using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkPlaceNameText : InfoText
{
    public override void SetText()
    {
        SetSelectedWorkPlace();
        newText = selectedWorkPlace.name;
        base.SetText();
    }
}

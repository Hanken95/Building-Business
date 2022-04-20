using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PraiseText : InfoText
{
    public override void SetText()
    {
        SetSelectedWorkPlace();
        newText = "Building praise: " + selectedWorkPlace.Praise.ToString();
        base.SetText();
    }

}

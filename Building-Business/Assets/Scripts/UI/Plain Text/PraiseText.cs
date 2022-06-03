using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PraiseText : InfoText
{
    public override void SetText()
    {
        SetSelectedWorkPlace();
        newText = "Workplace praise: " + selectedWorkPlace.Praise.ToString();
        base.SetText();
    }

}

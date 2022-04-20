using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplaintsText : InfoText
{

    public override void SetText()
    {
        SetSelectedWorkPlace();
        newText = "Building complaints: " + selectedWorkPlace.Complaints.ToString();
        base.SetText();
    }
}

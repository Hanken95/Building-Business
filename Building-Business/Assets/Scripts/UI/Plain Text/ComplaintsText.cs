using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplaintsText : InfoText
{
    private void Start()
    {
        SetText("Building complaints: " + selectedWorkPlace.Complaints.ToString());
    }
}

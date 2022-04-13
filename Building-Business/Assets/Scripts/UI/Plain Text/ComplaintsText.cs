using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplaintsText : InfoText
{
    private void Start()
    {
        UpdateComplaints();
    }

    public void UpdateComplaints()
    {
        SetText("Building complaints: " + selectedWorkPlace.Complaints.ToString());
    }
}

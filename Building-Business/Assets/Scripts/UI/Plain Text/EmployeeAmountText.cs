using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeAmountText : InfoText
{

    public override void SetText()
    {
        SetSelectedWorkPlace();
        newText = "Employees: " + selectedWorkPlace.Employees.Count.ToString() + "/" +
            selectedWorkPlace.MaxEmployees;
        base.SetText();
    }
}

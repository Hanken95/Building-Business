using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeText : InfoText
{
    private void Start()
    {
        SetText("Employees: " + selectedWorkPlace.Employees.Count.ToString() + "/" + 
            selectedWorkPlace.MaxEmployees);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfoMenu : MonoBehaviour
{

    public EmployeesPage employeesPage;

    public List<InfoText> infoTexts = new List<InfoText>();



    private void OnEnable()
    {
        RefreshPages();
    }

    private void RefreshPages()
    {
        if (employeesPage.buttonsSet)
        {
            employeesPage.SetEmployeeButtons();
        }
    }
}

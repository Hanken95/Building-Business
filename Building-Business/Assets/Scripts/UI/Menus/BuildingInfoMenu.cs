using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfoMenu : MonoBehaviour
{

    public EmployeesPage employeesPage;

    List<InfoText> infoTexts = new List<InfoText>();


    private void OnEnable()
    {
        RefreshPages();
    }

    private void RefreshPages()
    {
        infoTexts.Add(FindObjectOfType<ComplaintsText>());
        infoTexts.Add(FindObjectOfType<EmployeeAmountText>());
        infoTexts.Add(FindObjectOfType<HappinessText>());
        infoTexts.Add(FindObjectOfType<IncomeText>());
        infoTexts.Add(FindObjectOfType<PraiseText>());

        foreach (var text in infoTexts)
        {
            if (text != null)
            {
                text.SetText();
            }
        }
        if (employeesPage.buttonsSet)
        {
            employeesPage.SetEmployeeButtons();
        }
    }
}

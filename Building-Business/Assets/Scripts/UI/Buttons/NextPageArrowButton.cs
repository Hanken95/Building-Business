using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPageArrowButton : ArrowButton
{
    protected override void SwitchPage()
    {
        employeesPage.NextSubPage();
        base.SwitchPage();
    }
}

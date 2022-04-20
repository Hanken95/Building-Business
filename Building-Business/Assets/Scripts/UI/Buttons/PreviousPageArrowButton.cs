using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousPageArrowButton : ArrowButton
{
    protected override void SwitchPage()
    {
        employeesPage.PreviousSubPage();
        base.SwitchPage();
    }
}

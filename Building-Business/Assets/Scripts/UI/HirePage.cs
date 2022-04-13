using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HirePage :PageWithItemButtons
{
    protected override void SelectUnselectedItemButton(ItemButton itemButton)
    {
        base.SelectUnselectedItemButton(itemButton);
        uIManager.EnableHireButton();
    }

    protected override void DeselectItemButton()
    {
        base.DeselectItemButton();
        uIManager.DisableHireButton();
    }
}


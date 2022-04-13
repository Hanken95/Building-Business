using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BuildingsForPurchasePage : PageWithItemButtons
{
    protected override void SelectUnselectedItemButton(ItemButton itemButton)
    {
        base.SelectUnselectedItemButton(itemButton);
        uIManager.EnablePurchaseButton();
        uIManager.objectToPurchase = itemButton.objectToPurchase.
            GetComponent<PurchaseAbleItem>();
    }

    protected override void DeselectItemButton()
    {
        base.DeselectItemButton();
        uIManager.DisablePurchaseButton();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BuildingsForPurchasePage : PageWithItemButtons
{
    protected override void SelectUnselectedItemButton(ItemButton itemButton)
    {
        base.SelectUnselectedItemButton(itemButton);
        if (itemButton.GetType() == typeof(BuildingItemButton))
        {
            var buildingItemButton = (BuildingItemButton)itemButton;
            uIManager.EnablePurchaseButton();
            uIManager.objectToPurchase = buildingItemButton.objectToPurchase.
                GetComponent<PurchaseAbleItem>();
        }
        else
        {
            Debug.Log("Not the right type");
        }
    }

    protected override void DeselectItemButton()
    {
        base.DeselectItemButton();
        uIManager.DisablePurchaseButton();
    }
}

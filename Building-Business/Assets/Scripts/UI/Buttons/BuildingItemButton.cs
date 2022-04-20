

using UnityEngine;
using UnityEngine.UI;

public class BuildingItemButton : ItemButton
{
    public GameObject objectToPurchase;

    private Text costText;


    protected override void Awake()
    {
        base.Awake();
        var cost = objectToPurchase.
            GetComponent<PurchaseAbleItem>().cost;
        costText = GetComponentInChildren<Text>();
        costText.text = cost.ToString() + " €";
    }
}


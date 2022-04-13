using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ItemButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public PageWithItemButtons page;

    internal Image background;

    public GameObject objectToPurchase;

    private Text costText;

    void Awake()
    {
        background = GetComponent<Image>();
        page.Subscribe(this);
        costText = GetComponentInChildren<Text>();
        var cost = objectToPurchase.GetComponent<PurchaseAbleItem>().cost;
        costText.text = cost.ToString() + " €";
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        page.OnButtonSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        page.OnButtonEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        page.OnButtonExit();
    }
}

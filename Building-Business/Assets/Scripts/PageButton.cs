using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PageButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public Page page;

    internal Image background;

    public GameObject objectToPurchase;

    void Start()
    {
        background = GetComponent<Image>();
        page.Subscribe(this);
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

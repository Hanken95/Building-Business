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

    protected virtual void Awake()
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

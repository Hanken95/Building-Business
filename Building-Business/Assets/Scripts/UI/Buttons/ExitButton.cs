using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitButton : TabButton
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        FindObjectOfType<UIManager>().CloseMenus();
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArrowButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public EmployeesPage employeesPage;

    public Color arrowIdle;
    public Color arrowHover;

    public void OnPointerClick(PointerEventData eventData)
    {
        GetComponent<Image>().color = arrowIdle;
        SwitchPage();
    }

    protected virtual void SwitchPage()
    {
        employeesPage.SetEmployeeButtons();
        GetComponent<Image>().color = arrowIdle;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = arrowHover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = arrowIdle;
    }
}

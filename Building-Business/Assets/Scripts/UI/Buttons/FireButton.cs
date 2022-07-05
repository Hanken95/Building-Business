using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FireButton : MonoBehaviour , IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    private UIManager uIManager;

    public Color buttonIdle;
    public Color buttonHover;
    public Color buttonActive;

    public EmployeesPage employeesPage;

    internal Image background;

    void Start()
    {
        background = GetComponent<Image>();
        uIManager = FindObjectOfType<UIManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        background.color = buttonHover;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        background.color = buttonActive;
        uIManager.selectedWorkplace.Fire(employeesPage.SelectedEmployee);
        employeesPage.employeeList.Remove(employeesPage.SelectedEmployee);
        if (employeesPage.employeeList.Count == 0)
        {
            uIManager.DisableFireButton();
        }
        else if (employeesPage.employeeItemButtons.Count < 2)
        {
            employeesPage.PreviousSubPage();
        }
        employeesPage.SetEmployeeButtons();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        background.color = buttonIdle;
    }
}

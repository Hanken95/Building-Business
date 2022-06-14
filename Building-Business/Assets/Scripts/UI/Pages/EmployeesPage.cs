using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class EmployeesPage : PageWithItemButtons
{
    public GameObject employeeButtonPrefab;
    public Transform firstRow;
    public Transform secondRow;
    public Transform thirdRow;
    public GameObject NextPageButton;
    public GameObject PreviousPageButton;
    public List<Employee> employeeList = new List<Employee>();
    public int employeesPerPage = 6;
    private int pageIndex = 1;

    private List<EmployeeItemButton> employeeItemButtons = new List<EmployeeItemButton>();
    private int startingIndex = 0;
    internal bool buttonsSet = false;
    private int maxPageNumber;

    protected override void SelectUnselectedItemButton(ItemButton itemButton)
    {
        base.SelectUnselectedItemButton(itemButton);
        uIManager.EnableFireButton();
    }

    protected override void DeselectItemButton()
    {
        base.DeselectItemButton();
        uIManager.DisableFireButton();
    }


    protected override void Start()
    {
        base.Start();
        SetEmployeeButtons();
        SetMaxPageNumber();
        UpdatePageCounter();
        buttonsSet = true;
    }

    internal void NextSubPage()
    {
        pageIndex++;
        SetStartingIndex();
        UpdatePageCounter();

        if (pageIndex >= maxPageNumber)
        {
            DisableNextPageArrow();
        }
        if (!PreviousPageButton.activeSelf)
        {
            EnablePreviousPageArrow();
        }
    }
    internal void PreviousSubPage()
    {
        pageIndex--;
        SetStartingIndex();
        UpdatePageCounter();

        if (pageIndex < 2)
        {
            DisablePreviousPageArrow();
        }
        if (!NextPageButton.activeSelf)
        {
            EnableNextPageArrow();
        }
    }

    private void UpdatePageCounter()
    {
        transform.GetChild(0).GetComponent<Text>().text = "";
        GetComponentInChildren<Text>().text = "Page " + pageIndex + "/" +
            maxPageNumber;
    }


    private void EnableNextPageArrow()
    {
        NextPageButton.SetActive(true);
    }

    private void DisableNextPageArrow()
    {
        NextPageButton.SetActive(false);
    }

    private void EnablePreviousPageArrow()
    {
        PreviousPageButton.gameObject.SetActive(true);
    }

    private void DisablePreviousPageArrow()
    {
        PreviousPageButton.SetActive(false);
    }

    private void SetStartingIndex()
    {
        startingIndex = (pageIndex - 1) * employeesPerPage;
    }
    public void SetEmployeeButtons()
    {
        DeleteEmployeeButtonsFromRows();
        employeeList.Clear();
        foreach (var employee in uIManager.selectedWorkplace.Employees)
        {
            employeeList.Add(employee);
        }
        //employeeList = uIManager.selectedWorkplace.Employees;
        GenerateEmployeeButtons();
        SetEmployeeButtonValues();
    }

    private void DeleteEmployeeButtonsFromRows()
    {
        DeleteChildren(firstRow);
        DeleteChildren(secondRow);
        DeleteChildren(thirdRow);
    }

    private void DeleteChildren(Transform transform)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void SetEmployeeButtonValues()
    {
        if (employeesPerPage >= employeeItemButtons.Count)
        {
            for (int i = 0; i < employeeItemButtons.Count; i++)
            {
                employeeItemButtons[i].SetEmployee(employeeList[i + ((pageIndex - 1) * 6)]);
                employeeItemButtons[i].SetTexts();
            }
        }
    }

    private void GenerateEmployeeButtons()
    {
        if (employeeItemButtons.Count > 0)
        {
            employeeItemButtons.Clear();
        }
        int loopStop = employeesPerPage + startingIndex;
        if (employeesPerPage + startingIndex > employeeList.Count)
        {
            loopStop = employeeList.Count;
        }
        for (int employeeIndex = startingIndex; employeeIndex < loopStop; 
            employeeIndex++)
        {
            employeeButtonPrefab.GetComponent<EmployeeItemButton>().page = this;
            if (employeeIndex % 3 == 0)
            {
                employeeItemButtons.Add(Instantiate(employeeButtonPrefab, firstRow).GetComponent<EmployeeItemButton>());
            }
            else if (employeeIndex % 2 == 0)
            {
                employeeItemButtons.Add(Instantiate(employeeButtonPrefab, thirdRow).GetComponent<EmployeeItemButton>());
            }
            else
            {
                employeeItemButtons.Add(Instantiate(employeeButtonPrefab, secondRow).GetComponent<EmployeeItemButton>());
            }
        }
    }

    private void SetMaxPageNumber()
    {
        maxPageNumber = ((employeeList.Count / employeesPerPage) + 1);
    }
}


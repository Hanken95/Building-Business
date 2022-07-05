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
    public List<Transform> rows = new List<Transform>();
    public GameObject NextPageButton;
    public GameObject PreviousPageButton;
    public List<Employee> employeeList = new List<Employee>();
    internal Employee SelectedEmployee { get; private set; }
    public int employeesPerPage = 6;
    private int pageIndex = 1;

    internal List<EmployeeItemButton> employeeItemButtons = new List<EmployeeItemButton>();
    private int startingIndex = 0;
    internal bool buttonsSet = false;
    private int pagesCount;

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
        buttonsSet = true;
    }

    public override void OnButtonSelected(ItemButton itemButton)
    {
        var selectedEmployeeItemButton = (EmployeeItemButton)itemButton;
        if (SelectedEmployee == null || selectedEmployeeItemButton.employee != SelectedEmployee)
        {
            SelectedEmployee = selectedEmployeeItemButton.employee;
        }
        else
        {
            SelectedEmployee = null;
        }
        base.OnButtonSelected(itemButton);
    }

    internal void NextSubPage()
    {
        pageIndex++;
        SetStartingIndex();
        UpdatePageCounter();
        uIManager.DisableFireButton();

        if (pageIndex >= pagesCount)
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
        uIManager.DisableFireButton();

        if (pageIndex < 2)
        {
            DisablePreviousPageArrow();
        }
        if (!NextPageButton.activeSelf && pageIndex < pagesCount)
        {
            EnableNextPageArrow();
        }
    }

    private void UpdatePageCounter()
    {
        SetMaxPageNumber();
        transform.GetChild(0).GetComponent<Text>().text = "";
        GetComponentInChildren<Text>().text = "Page " + pageIndex + "/" +
            pagesCount;
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
        UpdatePageCounter();
        GenerateEmployeeButtons();
        SetEmployeeButtonValues();
    }

    private void DeleteEmployeeButtonsFromRows()
    {
        foreach (Transform row in rows)
        {
            DeleteItemButtonsInRow(row);
        }
    }

    private void DeleteItemButtonsInRow(Transform row)
    {
        foreach (Transform child in row)
        {
            Destroy(child.gameObject);
            itemButtons.Remove(child.GetComponent<ItemButton>());
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
        int employeesOnThisPage = employeeList.Count % employeesPerPage;
        if (pageIndex < pagesCount || pageIndex == 1 && employeeList.Count >= employeesPerPage)
        {
            employeesOnThisPage = employeesPerPage;
        }
        for (int employeeIndex = 0; employeeIndex < employeesOnThisPage; 
            employeeIndex++)
        {
            if (employeeButtonPrefab.GetComponent<EmployeeItemButton>().page != this)
            {
                employeeButtonPrefab.GetComponent<EmployeeItemButton>().page = this;
            }
            if (employeeIndex == 0 || employeeIndex == 3)
            {
                employeeItemButtons.Add(Instantiate(employeeButtonPrefab, rows[0]).GetComponent<EmployeeItemButton>());
            }
            else if (employeeIndex == 2 || employeeIndex == 5)
            {
                employeeItemButtons.Add(Instantiate(employeeButtonPrefab, rows[2]).GetComponent<EmployeeItemButton>());
            }
            else
            {
                employeeItemButtons.Add(Instantiate(employeeButtonPrefab, rows[1]).GetComponent<EmployeeItemButton>());
            }
        }
    }

    private void SetMaxPageNumber()
    {
        pagesCount = (((employeeList.Count - 1) / employeesPerPage) + 1);
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
}


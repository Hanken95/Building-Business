using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeItemButton : ItemButton
{
    internal Employee employee;

    public void SetTexts()
    {
        transform.GetChild(1).GetComponent<Text>().text = employee.name;
        transform.GetChild(2).GetComponent<Text>().text = "Happiness: " + employee.Happiness.ToString();
        transform.GetChild(3).GetComponent<Text>().text = "Skill level: " + employee.SkillLevel.ToString();
    }

    internal void SetEmployee(Employee employee)
    {
        this.employee = employee;
    }
}


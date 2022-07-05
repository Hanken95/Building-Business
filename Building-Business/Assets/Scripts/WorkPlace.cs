using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workplace : Building
{
    public List<double> employeeHappinessList = new List<double>();

    public int MaxEmployees { get; protected set; } = 40;
    protected float moneyGeneratedPerEmployeeSkillPoint;
    protected double happinessEffect = 0;
    public int Complaints { get; private set; } = 0;
    public int Praise { get; private set; } = 0;

    public List<Employee> Employees { get; private set; } = new List<Employee>();

    protected virtual void Start()
    {
        FindObjectOfType<Player>().AddWorkplace(this);
        if (happinessEffect != 0)
        {
            InvokeRepeating("ChangeHappiness", 0f, GameManager.gameTickTime);
        }
    }

    public bool Hire(Employee employee)
    {
        if (Employees.Count < MaxEmployees)
        {
            Employees.Add(employee);
            employee.SetWorkPlace(this);
            return true;
        }
        return false;
    }

    public void Fire(Employee employee)
    {
        Employees.Remove(employee);
        employee.LeaveWorkPlace();
    }

    private void ChangeHappiness()
    {
        if (GameManager.GamePaused)
        {
            return;
        }
        if (Employees.Count > 0)
        {
            if (happinessEffect > 0)
            {
                foreach (Person employee in Employees)
                {
                    if (employee.IncreaseHappiness(happinessEffect))
                    {
                        Praise++;
                    }
                }
            }
            else if (happinessEffect < 0)
            {
                foreach (Person employee in Employees)
                {
                    if (employee.DecreaseHappiness(happinessEffect))
                    {
                        Complaints++;
                    }
                }
            }
        }
    }

    public float GetWorkplaceIncome()
    {
        float totalIncome = 0;
        foreach (Person employee in Employees)
        {
            totalIncome += employee.SkillLevel * moneyGeneratedPerEmployeeSkillPoint;
        }
        return totalIncome;
    }
    public double GetWorkplaceTotalHappiness()
    {
        double totalHappiness = 0;
        foreach (Person employee in Employees)
        {
            totalHappiness += employee.Happiness;
        }
        return totalHappiness;
    }

    protected void HireRandomlyGeneratedPeople(int numberOfEmployees)
    {
        for (int i = 0; i < numberOfEmployees; i++)
        {
            Employee employee = new Employee();
            Hire(employee);
            employeeHappinessList.Add(employee.Happiness);
        }
    }
}

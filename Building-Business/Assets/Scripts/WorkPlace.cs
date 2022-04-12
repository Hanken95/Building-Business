using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workplace : Building
{
    public int MaxEmployees { get; protected set; } = 40;
    protected float moneyGeneratedPerEmployeeSkillPoint;
    protected float happinessEffect = 0;
    public int Complaints { get; private set; } = 0;
    public int Praise { get; private set; } = 0;

    public List<Person> Employees { get; private set; } = new List<Person>();

    private void Start()
    {
        FindObjectOfType<Player>().AddWorkplace(this);
        InvokeRepeating("ChangeHappiness", 0f, GameManager.gameTickTime);
    }

    public bool Hire(Person employee)
    {
        if (Employees.Count < MaxEmployees)
        {
            Employees.Add(employee);
            return true;
        }
        return false;
    }

    public void Fire(Person employee)
    {
        Employees.Remove(employee);
    }

    private void ChangeHappiness()
    {
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
    public float GetWorkplaceTotalHappiness()
    {
        float totalHappiness = 0;
        foreach (Person employee in Employees)
        {
            totalHappiness += employee.Happiness;
        }
        return totalHappiness;
    }

}

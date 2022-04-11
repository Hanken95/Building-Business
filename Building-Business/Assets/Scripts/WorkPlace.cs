using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkPlace : PurchaseAbleItem
{
    protected int maxEmployees;
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
        if (Employees.Count < maxEmployees)
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
                    if (employee.DecreaseHappiness(happinessEffect))
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
            totalIncome += employee.skillLevel * moneyGeneratedPerEmployeeSkillPoint;
        }
        return totalIncome;
    }
}

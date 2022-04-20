

using System;
using System.Collections.Generic;

public class Factory : Workplace
{
    private Factory()
    {
        cost = 120;
        value = 60;
        moneyGeneratedPerEmployeeSkillPoint = 1.2f;
        happinessEffect = 0.1;
        MaxEmployees = 30;
    }

    protected override void Start()
    {
        base.Start();
        Hire(new Employee("Trump", -2, 0));
        Hire(new Employee("Gert", 1.5, 3));
        Hire(new Employee("Lia", -1, 2));
        Hire(new Employee("Bert", 4, 1));
        Hire(new Employee("Fia", 2, 5));
        HireRandomlyGeneratedPeople(5);
    }

    
}


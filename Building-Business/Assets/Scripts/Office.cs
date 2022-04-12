using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Office : Workplace
{
    private Office()
    {
        cost = 100;
        value = 75;
        moneyGeneratedPerEmployeeSkillPoint = 1;
        MaxEmployees = 60;
    }
    
}

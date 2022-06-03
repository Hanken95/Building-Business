using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Employee : Person
{
    private Workplace workplace;

    public Employee() : base()
    {
        
    }

    public Employee(string name) : base(name)
    {

    }

    public Employee(string name, double happiness, int skillLevel) : base(name, happiness, skillLevel)
    {
    }

    public void SetWorkPlace(Workplace workplace)
    {
        this.workplace = workplace;
    }

    public void LeaveWorkPlace()
    {
        workplace = null;
    }

    public string GetWorkPlacename()
    {
        return workplace.name;
    }

    
}


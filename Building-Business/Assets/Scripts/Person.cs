using System;

public class Person
{
    internal double Happiness { get; private set; }

    internal int SkillLevel { get; private set; }

    internal string name;
    internal int cost = 10;
    private float maxHappiness = 10;
    private float minHappiness = -10;
    private Random random = new Random();

    internal Person()
    {
        SetRandomStartingValues();
        name = RandomNameGenerator.GenerateRandomName();
    }

    internal Person(string name)
    {
        SetRandomStartingValues();
        this.name = name;
    }

    public Person(string name, double happiness, int skillLevel)
    {
        this.name = name;
        Happiness = happiness;
        SkillLevel = skillLevel;
    }

    private void SetRandomStartingValues()
    {
        var hap = random.Next(-1, 3);
        Happiness = hap;
        SkillLevel = random.Next(1, 5);
    }

    public bool IncreaseHappiness(double amount)
    {
        if (Happiness < maxHappiness)
        {
            Happiness += amount;
            return false;
        }
        return true;
    }
    public bool DecreaseHappiness(double amount)
    {
        if (Happiness > minHappiness)
        {
            Happiness += amount;
            return false;
        }
        return true;
    }

}
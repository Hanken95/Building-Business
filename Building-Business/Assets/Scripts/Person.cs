using System;

public class Person
{
    internal float Happiness { get; private set; } = 3;
    internal int SkillLevel { get; private set; }

    internal string name;
    private float maxHappiness = 10;
    private float minHappiness = -10;
    private Random random = new Random();

    internal Person()
    {
        SetRandomStartingValues();
    }

    private void SetRandomStartingValues()
    {
        Happiness = random.Next(-1, 3);
        SkillLevel = random.Next(1, 5);
        name = RandomNameGenerator.GenerateRandomName();
    }

    public bool IncreaseHappiness(float amount)
    {
        if (Happiness < maxHappiness)
        {
            Happiness += amount;
            return false;
        }
        return true;
    }
    public bool DecreaseHappiness(float amount)
    {
        if (Happiness > minHappiness)
        {
            Happiness += amount;
            return false;
        }
        return true;
    }

}
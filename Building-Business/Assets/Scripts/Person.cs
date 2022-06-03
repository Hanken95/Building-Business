using System;

public class Person
{
    internal double Happiness { get; private set; }

    internal int SkillLevel { get; private set; }

    internal string name;
    internal int cost = 10;
    private double maxHappiness = 10;
    private double minHappiness = -10;
    private static readonly Random random = new Random(); 
    private static readonly object syncLock = new object();


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
        Happiness = RandomNumber(-1, 3);
        SkillLevel = RandomNumber(1, 5);
    }

    public static int RandomNumber(int min, int max)
    {
        lock (syncLock)
        { 
            return random.Next(min, max);
        }
    }


    public bool IncreaseHappiness(double amount)
    {
        if (Happiness < maxHappiness)
        {
            Happiness += amount;
            if (Happiness > maxHappiness)
            {
                Happiness = maxHappiness;
                return true;
            }
            return false;
        }
        return true;
    }
    public bool DecreaseHappiness(double amount)
    {
        if (Happiness > minHappiness)
        {
            Happiness += amount;
            if (Happiness < minHappiness)
            {
                Happiness = minHappiness;
                return true;
            }
            return false;
        }
        return true;
    }

}
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
        Happiness = RandomDoubleNumber(-1, 30);
        SkillLevel = RandomIntNumber(1, 50);
    }

    public static int RandomIntNumber(int min, int max)
    {
        lock (syncLock)
        { 
            return random.Next(min, max);
        }
    }
    
    public static double RandomDoubleNumber(int min, int max)
    {
        double returnValue = RandomIntNumber(min, max);
        double randomDoubleValue;
         
        lock (syncLock)
        {
            randomDoubleValue = Math.Round(random.NextDouble(), 1);
        }

        if (CoinFlip())
        {
            return returnValue - randomDoubleValue;
        }
        return returnValue + randomDoubleValue;
    }

    private static bool CoinFlip()
    {
        int coinFlip;
        lock (syncLock)
        {
            coinFlip = random.Next(2);
        }
        return coinFlip == 1;
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
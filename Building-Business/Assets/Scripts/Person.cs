public class Person
{
    public string name;
    public float Happiness { get; private set; }
    public int skillLevel;
    private float maxHappiness = 10;
    private float minHappiness = 1;

    public void IncreaseHappiness(float amount)
    {
        if (Happiness < maxHappiness)
        {
            Happiness += amount;
        }
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
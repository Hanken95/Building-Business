

using UnityEngine;

class Player : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        InvokeRepeating("GenerateMoney", 0.95f, 1);
    }

    public string Name = "Britta";
    public int Money { get; private set; } = 0;
    public int Income = 5;
    public int Experience = 0;


    public void GenerateMoney()
    {
        if (!gameManager.GamePaused)
        {
            ChangeMoneyByAmount(Income);
        }
    }

    public void ChangeMoneyByAmount(int amount)
    {
        Money += amount;
    }
}


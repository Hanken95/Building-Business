

using UnityEngine;

class Player : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        InvokeRepeating("GenerateMoney", 0.95f, 3);
    }

    public string Name = "Britta";
    public int money = 300;
    public int income = 5;
    public int experience = 0;


    private void GenerateMoney()
    {
        if (!gameManager.GamePaused)
        {
            money += income;
        }
    }

}


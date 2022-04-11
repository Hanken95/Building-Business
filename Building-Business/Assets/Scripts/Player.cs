

using System.Collections.Generic;
using UnityEngine;

class Player : MonoBehaviour
{
    GameManager gameManager;
    List<WorkPlace> workPlaces = new List<WorkPlace>();
    public int TotalPraise { get; private set; } = 1;
    public int TotalComplaints { get; private set; } = 2;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        InvokeRepeating("GenerateMoney", 0f, GameManager.gameTickTime);
        InvokeRepeating("GatherPraiseAndComplaints", 0f, GameManager.gameTickTime);
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

    public void AddWorkplace(WorkPlace workPlace)
    {
        workPlaces.Add(workPlace);
    }

    public void SetPlayerTotalIncome()
    {
        float totalPlayerIncome = 0;
        foreach (WorkPlace workPlace in workPlaces)
        {
            totalPlayerIncome += workPlace.GetWorkplaceIncome();
        }
        income = (int)totalPlayerIncome;
    }

    private void GatherPraiseAndComplaints()
    {
        if (workPlaces.Count > 0)
        {
            int praise = 0;
            int complaints = 0;

            foreach (WorkPlace workPlace in workPlaces)
            {
                praise += workPlace.Praise;
                complaints += workPlace.Complaints;
            }
            TotalPraise = praise;
            TotalComplaints = complaints;
        }
    }
}


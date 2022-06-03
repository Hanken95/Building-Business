

using System.Collections.Generic;
using UnityEngine;

class Player : MonoBehaviour
{
    static List<Workplace> workPlaces = new List<Workplace>();
    public int TotalPraise { get; private set; } = 1;
    public int TotalComplaints { get; private set; } = 2;

    public string Name = "Britta";
    public int money = 300;
    public int income = 5;
    public int experience = 0;

    void Start()
    {
        InvokeRepeating("GenerateMoney", 0f, GameManager.gameTickTime);
        InvokeRepeating("GatherPraiseAndComplaints", 0f, GameManager.gameTickTime);
    }

    private void GenerateMoney()
    {
        if (!GameManager.GamePaused)
        {
            money += income;
        }
    }

    public void AddWorkplace(Workplace workPlace)
    {
        workPlaces.Add(workPlace);
    }

    public static int GetWorplacesCount()
    {
        return workPlaces.Count;
    }

    public void SetPlayerTotalIncome()
    {
        float totalPlayerIncome = 0;
        foreach (Workplace workPlace in workPlaces)
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

            foreach (Workplace workPlace in workPlaces)
            {
                praise += workPlace.Praise;
                complaints += workPlace.Complaints;
            }
            TotalPraise = praise;
            TotalComplaints = complaints;
        }
    }
}


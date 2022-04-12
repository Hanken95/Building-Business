using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public bool GamePaused { get; private set; } = false;
    public static float gameTickTime = 3;
    internal List<Person> availablePeople = new List<Person>();
    private int availablePeopleStartingAmount = 30;

    void Awake()
    {
        for (int i = 0; i < availablePeopleStartingAmount; i++)
        {
            availablePeople.Add(new Person());
        }
    }

    public void PauseGame() 
    {
        GamePaused = true;
    }

    public void ResumeGame() 
    {
        GamePaused = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public bool GamePaused { get; private set; } = false;
    public static float gameTickTime = 3;

    public void PauseGame() 
    {
        GamePaused = true;
    }

    public void ResumeGame() 
    {
        GamePaused = false;
    }
}

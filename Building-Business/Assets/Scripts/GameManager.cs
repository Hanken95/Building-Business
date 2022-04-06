using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    internal bool GamePaused { get; private set; } = false;

    public void PauseGame() 
    {
        GamePaused = true;
    }

    public void ResumeGame() 
    {
        GamePaused = false;
    }
}

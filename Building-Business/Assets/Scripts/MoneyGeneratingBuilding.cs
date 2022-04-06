using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGeneratingBuilding : MonoBehaviour
{
    internal int moneyPerSecond = 5;
    void Start()
    {
        FindObjectOfType<Player>().Income += moneyPerSecond;
    }


}

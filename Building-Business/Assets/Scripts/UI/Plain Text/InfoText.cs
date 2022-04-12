using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class InfoText : MonoBehaviour
{
    protected Workplace selectedWorkPlace;

    void Awake()
    {
        selectedWorkPlace =  FindObjectOfType<UIManager>().selectedWorkplace;
    }

    protected void SetText(string newText)
    {
        GetComponent<Text>().text = newText;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class InfoText : MonoBehaviour
{
    protected Workplace selectedWorkPlace;
    protected string newText;


    protected void OnEnable()
    {
        SetText();
    }

    protected void SetSelectedWorkPlace()
    {
        if (selectedWorkPlace != FindObjectOfType<UIManager>().selectedWorkplace)
        {
            selectedWorkPlace = FindObjectOfType<UIManager>().selectedWorkplace;
        }
    }

    public virtual void SetText()
    {
        GetComponent<Text>().text = newText;
    }
}

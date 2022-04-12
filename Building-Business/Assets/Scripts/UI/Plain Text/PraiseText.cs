using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PraiseText : InfoText
{
    private void Start()
    {
        SetText("Building praise: " + selectedWorkPlace.Praise.ToString());
    }
}

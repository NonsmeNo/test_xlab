using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolChangeController : MonoBehaviour
{
    [SerializeField] private VilagerToolChange[] _vilagers;
    public void Change()
    {
        foreach (var vilager in _vilagers)
        {
            vilager.Change();
        }
    }
}

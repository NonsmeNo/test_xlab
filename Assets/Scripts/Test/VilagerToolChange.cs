using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VilagerToolChange : MonoBehaviour
{
   [SerializeField] private GameObject[] _tools;

    private void Start()
    {
        Change();
    }
   public void Change()
   {
        var index = Random.Range(0, _tools.Length);
        for (int i = 0; i < _tools.Length; ++i)
        {
            _tools[i].SetActive(i == index);
        }
   }

}

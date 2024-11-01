using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBLogger : MonoBehaviour
{

    
    private void Awake()
    {
        Log("Awake");
    }
    private void OnEnable()
    {
        Log("OnEnable");
    }

    private void Start()
    {
        Log("Start");
    }

    private void FixedUpdate()
    {
    }
    
    private void Update()
    {
    }


    public void LateUpdate()
    {
    }

    private void OnDisable()
    {
        Log("OnDisable");
    }


    private void OnDestroy()
    {
        Log("OnDestroy");
    }

    private void Log(string message)
    {
        Debug.Log($"{name}: {message} - frame: {Time.frameCount}");
    }
    
}

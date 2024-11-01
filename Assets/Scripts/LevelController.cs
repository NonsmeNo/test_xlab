using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private StoneSpawner _stoneSpawner;
    private float _timer;
    [SerializeField] private float _delay;

    public void Start()
    {
        _timer = Time.time;
    }
    public void Update()
    {
        if (Time.time > _timer + _delay)
        {
            _stoneSpawner.Spawn();
            _timer = Time.time;
        }
    }
}

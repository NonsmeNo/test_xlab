using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private GameObject _prefab;

    private void Start()
    {
        if (_point == null)
        {
            _point = transform;
        }
    }
    public void Spawn ()
    {
        Instantiate(_prefab, _point.position, _point.rotation);
    }
}

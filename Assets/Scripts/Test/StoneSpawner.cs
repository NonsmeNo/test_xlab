using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private GameObject[] _prefabs;

    [SerializeField] private GameObject _dynamite;
    public AudioSource dynamiteSound;

    private void Start()
    {
        if (_point == null)
        {
            _point = transform;
        }
    }
    public GameObject Spawn()
    {
        int index = Random.Range(0, _prefabs.Length);
        return Instantiate(_prefabs[index], _point.position, _point.rotation);
    }
    public GameObject SpawnDynamite()
    {
        dynamiteSound.Play();
        return Instantiate(_dynamite, _point.position, _point.rotation);
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private FreeCamera _freeCamera;

    [SerializeField] private GameObject _ui;
    [SerializeField] private StoneSpawner _stoneSpawner;


    private void Update()
    {
        if (_ui.activeSelf)
        {
            return;
        }
        
        if (!_ui.activeSelf && _freeCamera != null)
        {
            _freeCamera.Move();
        }

        if (_stoneSpawner != null)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                _stoneSpawner.Spawn();
            }
        }
    }

}

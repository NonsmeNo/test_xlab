using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private FreeCamera _freeCamera;

        [SerializeField] private GameObject _ui;
        [SerializeField] private StoneSpawner _stoneSpawner;
        [SerializeField] private CloudController _cloudController;
        [SerializeField] private ToolChangeController _toolChangeController;


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

            if (_cloudController != null)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    _cloudController.MoveNext();
                }
            }
            if (_toolChangeController != null)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _toolChangeController.Change();
                }
            }

        }

    }
}


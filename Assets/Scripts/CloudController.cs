using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CloudController : MonoBehaviour {
    [SerializeField] private Transform _cloud;
    [SerializeField] private Transform[] _pointsPeople;
    [SerializeField] private float _speed = 3f;

    private int _curPointIndex = -1;
   private bool _isMove = false;

    public void MoveNext()
    {
        
        if(_curPointIndex >= 0)
        {
            _curPointIndex++;

            if (_curPointIndex >= _pointsPeople.Length)
            {
                _curPointIndex = 0;
            }
        }
        else
        {
            _curPointIndex = 0;
        }

        _isMove = true;
    }

    private Vector3 GetPoint(int index)
    {
        var point = _pointsPeople[index].position;
        point.y = _cloud.position.y;
        return point;
    }

    private void Update()
    {
        if (!_isMove)
        {
            return;
        }

        var point = GetPoint(_curPointIndex);
        _cloud.position = Vector3.Lerp(_cloud.position, point, Time.deltaTime);

        if (Vector3.Distance(_cloud.position, point) < 1f)
        {
            _isMove = false;
        }
    }
}

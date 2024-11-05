using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Stick : MonoBehaviour
    {

        public float maxAngle = 30f;
        public float speed = 360f;
        public float power = 10f;


        private bool _isDown = false;
        private Rigidbody _rigidbody;

        public Transform point;
        public event System.Action OnCollisionStone;

        private Vector3 _lastPointPosition;
        private Vector3 _dir; //направление


        


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }


        public void Down() // нажал
        {
            _isDown = false;
        }
        public void Up() // отжал
        {
            _isDown = true;
        }

        private void FixedUpdate()
        {
            Vector3 angle = transform.localEulerAngles;
            if (_isDown)
            {
                angle.z = Mathf.MoveTowardsAngle(angle.z, -maxAngle, speed * Time.deltaTime); //в FixedUpdate deltatime = fixeddeltatime
            }
            else
            {
                angle.z = Mathf.MoveTowardsAngle(angle.z, maxAngle, speed * Time.deltaTime);
            }

            transform.localEulerAngles = angle;

            _dir = (point.position - _lastPointPosition).normalized;
            _lastPointPosition = point.position;
        }

        private void OnCollisionEnter(Collision other) //для того чтобы камень отталкивался от клюшки
        {
            if (other.gameObject.TryGetComponent<Stone>(out var stone) && !stone.isDirty) 
            {
                stone.isDirty = true;
                var contact = other.contacts[0];
                //Debug.Log($"{contact.point} - {contact.normal} - {contact.impulse}");
                other.rigidbody.AddForce(_dir * power, ForceMode.Impulse);
                OnCollisionStone?.Invoke();
            }
        }
    }
}


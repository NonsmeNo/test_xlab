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
        public Rigidbody _rigidbody;

        public Transform point;

        private Vector3 _lastPointPosition;


        private void Awake()
        {_rigidbody = GetComponent<Rigidbody>();}


        public void Down()
        {
            _isDown = false;
        }
        public void Up()
        {
            _isDown = true;
        }

        private void Update()
        {
            _lastPointPosition = point.position;
        }


        private void FixedUpdate()
        {
            Vector3 angle = transform.localEulerAngles;
            if (Input.GetMouseButton(0))
            {
                angle.z = Mathf.MoveTowardsAngle(angle.z, -maxAngle, speed * Time.deltaTime);
            }
            else
            {
                angle.z = Mathf.MoveTowardsAngle(angle.z, maxAngle, speed * Time.deltaTime);
            }

            transform.localEulerAngles = angle;

           // _rigidbody.MoveRotation();
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log(other, this);
            if (other.rigidbody)
            {
                var contact = other.contacts[0];
                Debug.Log($"{contact.point} - {contact.normal} - {contact.impulse}");
                //other.rigidbody.AddForce(_dir * power, ForceMode.Impulse);
            }
        }
    }
}


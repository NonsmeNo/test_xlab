using System;
using UnityEngine;


namespace Golf
{
    public class PlayerController : MonoBehaviour

    {

        public Transform stick;
        public float maxAngle = 30f;
        public float speed = 1f;

        private void Awake()
        {
            Application.targetFrameRate = 30;
        }
        private void FixedUpdate()
        {
            
            if (Input.GetMouseButton(0))
            {
                
            }
            else
            {
                
            }


        }


    }
}
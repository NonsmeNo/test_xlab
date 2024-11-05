using System;
using UnityEngine;


namespace Golf
{
    public class PlayerController : MonoBehaviour

    {

        public Stick stick;

        private void Awake()
        {
            Application.targetFrameRate = 30;
        }
        private void FixedUpdate()
        {

            if (Input.GetMouseButton(0))
            {
                stick.Down();
            }
            else
            {
                stick.Up();
            }
        }
    }
}
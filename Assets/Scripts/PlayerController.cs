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

            // if (Input.GetMouseButton(0))
            // {
            //     PointerDown();
            // }
            // else
            // {
            //     PointerUp();
            // }
        }

        private void OnDisable()
        {
            if (stick != null)
            {
                stick.Reset();
            }
        }

        public void PointerDown()
        {
            stick.Down();
        }
        public void PointerUp()
        {
            stick.Up();
        }

    }
}
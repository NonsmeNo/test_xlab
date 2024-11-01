using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Stone : MonoBehaviour
    {
        public event Action OnCollisionStick;
        public event Action OnCollisionStone;

        // private void OnCollisionEnter(Collider other)
        // {
        //     if (other.gameObject.GetComponent<Stone>())
        //     {
        //         OnCollisionStone?.Invoke();
        //     }
        //     else if (other.gameObject.GetComponent<Collider>())
        //     {
                
        //     }
        // }
    }
}

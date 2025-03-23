using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Dynamite : MonoBehaviour
    {
        public event Action OnCollisionDynamite;

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("я попал сюда");

            if (other.gameObject.TryGetComponent<Stick>(out var stone))
            {
                OnCollisionDynamite?.Invoke();
            }
            Destroy(gameObject, 0.4f);
        }
    }
}

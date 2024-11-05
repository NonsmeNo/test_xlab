using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public Stick stick;
        public StoneSpawner stoneSpawner;
        private float _timer;
        private float _delay = 2f;
        private uint _score = 0;


        private List<Stone> _stones = new List<Stone>();

        public void OnEnable()
        {
            _timer = Time.time - _delay;
            stick.OnCollisionStone += OnCollisionStick;
        }
        public void OnDisable()
        {
            if (stick)
            {
                stick.OnCollisionStone -= OnCollisionStone;
            }
        }

       

        public void Update()
        {
            if (Time.time > _timer + _delay)
            {
                _timer = Time.time;

                var go = stoneSpawner.Spawn();
                var stone = go.GetComponent<Stone>();

                stone.OnCollisionStone += OnCollisionStone;

                _stones.Add(stone);
            }
        }

        private void OnCollisionStone()
        {
            Debug.Log("GAME OVER!!!!!");
        }
         private void OnCollisionStick()
        {
            _score++;
            Debug.Log($"score: {_score}");
        }
    }

}

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
        private float _delay = 2f; // задержка, с которой будут подаваться камни
        private int _score = 0;


        public event Action<int> onGameOver;
        public event Action<int> onScoreInc;


        private List<Stone> _stones = new List<Stone>();

        //public LevelSettings levelSettings;

        public void OnEnable()
        {
            _timer = Time.time - _delay;
            stick.OnCollisionStone += OnCollisionStick;

            _score = 0;
            
            var ls = Resources.Load<LevelSettings>("LevelSettings 0");

            _delay = ls.stoneFallDelay;
            ClearStones();
        }
        public void OnDisable()
        {
            if (stick)
            {
                stick.OnCollisionStone -= OnCollisionStick;
            }
        }

        private void ClearStones()
        {
            foreach (var stone in _stones)
            {
                Destroy(stone.gameObject);
            }
            _stones.Clear();
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
            onGameOver?.Invoke(_score);        
        }

         private void OnCollisionStick()
        {
            _score++;
            Debug.Log($"score: {_score}");
            onScoreInc?.Invoke(_score); 
        }
    }

}

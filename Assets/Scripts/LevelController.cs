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
        private int _nextInterval;


        public event Action<int> onGameOver;
        public event Action<int> onScoreInc;


        private List<Stone> _stones = new List<Stone>();

        //public LevelSettings levelSettings;

        private LevelSettings[] _levelSettingsArray;


        public void OnEnable()
        {
            _timer = Time.time - _delay;
            stick.OnCollisionStone += OnCollisionStick;

            _score = 0;
            _levelSettingsArray = Resources.LoadAll<LevelSettings>("");
            var ls = Resources.Load<LevelSettings>("LevelSettings 0");

            _delay = ls.stoneFallDelay;

            SetNextInterval();
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
                if (_score == _nextInterval)
                {
                    int randomIndex = UnityEngine.Random.Range(0, _levelSettingsArray.Length);
                    var ls = _levelSettingsArray[randomIndex];
                    _delay = ls.stoneFallDelay;
                    SetNextInterval();


                    var go = stoneSpawner.SpawnDynamite();
                    var dynamite = go.GetComponent<Dynamite>();
                    dynamite.OnCollisionDynamite += OnCollisionDynamite;
                }
                else
                {
                    var go = stoneSpawner.Spawn();
                    var stone = go.GetComponent<Stone>();

                    stone.OnCollisionStone += OnCollisionStone;

                    _stones.Add(stone);
                }
            }
        }

        private void OnCollisionDynamite()
        {
            Debug.Log("GAME OVER!!!!!");
            onGameOver?.Invoke(_score);
        }

        private void SetNextInterval()
        {
            int randomInterval = UnityEngine.Random.Range(3, 7);
            _nextInterval = _score + randomInterval;
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

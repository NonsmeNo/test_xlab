using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Golf
{
    public class GamePlayState : MonoBehaviour
    {
        public GameObject rootUI;
        public MainMenuState mainMenuState;
        public GamePlayState gamePlayState;

        public PlayerController playerController;
        public LevelController levelController;


        private void OnEnable()
        {
            playerController.enabled = true;
            levelController.enabled = true;

        }

        private void OnDisable()
        {
        }

    


    }
}

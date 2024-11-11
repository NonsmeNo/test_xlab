using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Golf
{
    public class MainMenuState : MonoBehaviour
    {
        public GameObject mainMenuUI;
        public GamePlayState gamePlayState;
        public TextMeshProUGUI scoreText;
        public AudioSource soundPlay;
        
        private void OnEnable()
        {
            mainMenuUI.SetActive(true);
            scoreText.text = $"TOP SCORE: {GameInstance.score}" ;
        }
        private void OnDisable()
        {
            if (mainMenuUI)
            {
                mainMenuUI.SetActive(false);
            }
        }
        public void Play()
        {
            gameObject.SetActive(false);
            gamePlayState.gameObject.SetActive(true);
        }

        public void PlayThisSoundEffect()
        {
            soundPlay.Play();
        }

        private void Exit()
        {

        }
    }
}

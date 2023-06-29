using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BallColourChange
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject playerCharacter;
        [SerializeField] private GameObject loseScreenCanvas;

        private CanvasGroup loseScreenCanvasGroup;

        public AnimationCurve timeScaleCurve;
        public float duration;

        private float initialTimeScale;

        private void Start()
        {
            Time.timeScale = 1;
            loseScreenCanvas.SetActive(false);
            loseScreenCanvasGroup = loseScreenCanvas.GetComponent<CanvasGroup>();
            initialTimeScale = Time.timeScale;
            playerCharacter = GameObject.FindGameObjectWithTag("Player");
        }

        private void OnEnable()
        {
            BallMovement.OnPlayerDeath += GameOver;
        }

        private void OnDisable()
        {
            BallMovement.OnPlayerDeath -= GameOver;
        }

        private void GameOver()
        {
            StartCoroutine(SlowDownTime());
            StartCoroutine(ShowFinalScreen());
        }

        private IEnumerator SlowDownTime()
        {
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                float normalizedTime = elapsedTime / duration;
                float curveValue = timeScaleCurve.Evaluate(normalizedTime);
                Time.timeScale = curveValue * initialTimeScale;

                elapsedTime += Time.unscaledDeltaTime;
                yield return null;
            }
        }

        private IEnumerator ShowFinalScreen()
        {
            loseScreenCanvasGroup.alpha = 0;
            loseScreenCanvas.SetActive(true);

            while (loseScreenCanvasGroup.alpha < 1)
            {
                loseScreenCanvasGroup.alpha += 1 * Time.deltaTime;
                yield return null;
            }
        }
    }
}
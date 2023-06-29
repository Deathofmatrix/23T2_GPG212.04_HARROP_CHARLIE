using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BallColourChange
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI finalTimeText;
        [SerializeField] private TextMeshProUGUI currentTimeText;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private string finalTime;

        private void Start()
        {
        }

        private void Update()
        {
            float milliseconds = Mathf.FloorToInt((Time.timeSinceLevelLoad % 1) * 100); 
            float seconds = Mathf.FloorToInt(Time.timeSinceLevelLoad % 60);
            float minutes = Mathf.FloorToInt(Time.timeSinceLevelLoad / 60);
            currentTimeText.text = $"{minutes:00}:{seconds:00}:{milliseconds:00}";
        }

        private void OnEnable()
        {
            BallMovement.OnPlayerDeath += CalculateFinalTime;
        }

        private void OnDisable()
        {
            BallMovement.OnPlayerDeath -= CalculateFinalTime;
        }

        private void CalculateFinalTime()
        {
            StartCoroutine(FadeTimerOut());
            finalTime = currentTimeText.text;
            finalTimeText.text = finalTime;
        }

        private IEnumerator FadeTimerOut()
        {
            canvasGroup.alpha = 1;
            gameObject.SetActive(true);

            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= 2 * Time.deltaTime;
                yield return null;
            }
        }
    }
}


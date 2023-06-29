using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BallColourChange
{
    public class TutorialManager : MonoBehaviour
    {
        [SerializeField] private int tutorialNumber = 0;
        [SerializeField] private TextMeshProUGUI tutorialText;
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject timer;
        [SerializeField] private GameObject mainMenuButton;
        [SerializeField] private GameObject finalScreen;
        private void OnEnable()
        {
            TutorialCollider.OnEnterTutorial += ChooseTutorial;
        }

        private void OnDisable()
        {
            TutorialCollider.OnEnterTutorial -= ChooseTutorial;
        }

        private void Start()
        {
            tutorialNumber = 0;
            tutorialText.gameObject.SetActive(false);
            finalScreen.SetActive(false);
        }

        private void ChooseTutorial()
        {
            switch (tutorialNumber)
            {
                default:
                    Debug.Log("No Case Avaliable");
                    break;
                case 0:
                    Tutorial1();
                    break;
                case 1:
                    Tutorial2();
                    break;
                case 2:
                    Tutorial3();
                    break;
                case 3:
                    Tutorial4();
                    break;
                case 4:
                    Tutorial5();
                    break;
            }

            EnterTutorialCollider();

            tutorialNumber++;
        }

        private void EnterTutorialCollider()
        {
            tutorialText.gameObject.SetActive(true);
            //animator.Play("TutorialTextFadeIn");
            Time.timeScale = 0f;
        }

        public void ExitTutorialCollider()
        {
            //animator.Play("TutorialTextFadeOut");
            tutorialText.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }

        private void Tutorial1()
        {
            tutorialText.text = "Tap to change the colour of the ball";
        }
        private void Tutorial2()
        {
            timer.SetActive(true);
            tutorialText.text = "The timer at the top tells you how long you've gone";
        }
        private void Tutorial3()
        {
            mainMenuButton.SetActive(true);
            tutorialText.text = "The button in the top left is to go back to the main menu";
        }
        private void Tutorial4()
        {
            tutorialText.text = "Tap to change to the same colour";
        }
        private void Tutorial5()
        {
            tutorialText.text = "";
            finalScreen.SetActive(true);    

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BallColourChange
{
    public class TouchManager : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject tutorialManager;
        private PlayerInput playerInput;

        private InputAction touchPressAction;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            touchPressAction = playerInput.actions["ChangeColour"];
        }

        private void OnEnable()
        {
            touchPressAction.started += TouchPressed;
        }

        private void OnDisable()
        {
            touchPressAction.started -= TouchPressed;
        }

        private void TouchPressed(InputAction.CallbackContext context)
        {
            if (player != null)
            {
                player.GetComponent<ColourChange>().OnTouch();
            }

            if (tutorialManager != null)
            {
                tutorialManager.GetComponent<TutorialManager>().ExitTutorialCollider();
            }
        }
    }
}


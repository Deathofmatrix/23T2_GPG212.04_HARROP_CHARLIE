using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BallColourChange
{
    public class ColourChange : MonoBehaviour
    {
        [SerializeField] private Color color1;
        [SerializeField] private Color color2;
        [SerializeField] private bool isColourOne;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void OnTouch()
        {
            Debug.Log("changecolour");
            if (isColourOne)
            {
                spriteRenderer.color = color2;
                isColourOne = false;
            }
            else
            {
                spriteRenderer.color = color1;
                isColourOne = true;
            }
        }
    }
}


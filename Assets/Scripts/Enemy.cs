using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BallColourChange
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        public bool isColourOne;
        [SerializeField] private bool isTutorialMode = false;
        [SerializeField] private float speed;

        [SerializeField] private Color colourOne;
        [SerializeField] private Color colourTwo;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            if (!isTutorialMode)
            {
                int randomColour = Random.Range(1, 3);
                isColourOne = randomColour == 1 ? true : false;
            }

            spriteRenderer.color = isColourOne ? colourOne : colourTwo;
        }

        private void FixedUpdate()
        {
            //Debug.Log(Time.time);
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}


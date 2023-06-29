using EasyAudioSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallColourChange
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private float speed;
        [SerializeField] private AnimationCurve speedCurve;
        [SerializeField] private float directionMoving;

        public delegate void PlayerDeathAction();
        public static event PlayerDeathAction OnPlayerDeath;

        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            speed = speedCurve.Evaluate(Time.timeSinceLevelLoad);
            rb2d.MovePosition(rb2d.position + Vector2.up * speed * directionMoving * Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("ScreenBoundaries"))
            {
                FindObjectOfType<AudioManager>().Play("Bounce");
                directionMoving = rb2d.position.y < 0 ? 1 : -1;
                Debug.Log(directionMoving);
            }
        }

        private void OnDisable()
        {
            OnPlayerDeath?.Invoke();

            Debug.Log("character disabled");
        }
    }
}
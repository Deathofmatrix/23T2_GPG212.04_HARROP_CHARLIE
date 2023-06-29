using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallColourChange
{
    public class TutorialCollider : MonoBehaviour
    {
        public delegate void EnterTutorialAction();
        public static event EnterTutorialAction OnEnterTutorial;

        [SerializeField] private float speed;

        private void FixedUpdate()
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Triggered");
                OnEnterTutorial();
            }
        }
    }
}

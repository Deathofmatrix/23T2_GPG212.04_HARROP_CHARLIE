using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallColourChange
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private float speed;

        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            rb2d.MovePosition(rb2d.position + Vector2.up * speed * Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("ScreenBoundaries"))
            {
                speed *= -1;
            }
        }
    }
}
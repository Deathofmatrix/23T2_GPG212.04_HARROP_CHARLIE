using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallColourChange
{
    public class Destroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}

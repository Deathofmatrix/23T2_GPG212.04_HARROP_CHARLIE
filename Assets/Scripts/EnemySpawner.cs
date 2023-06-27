using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BallColourChange
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemyPrefabs;
        [SerializeField] private float enemyInterval;

        private void Start()
        {
            StartCoroutine(spawnEnemyOnTimer(enemyInterval));
        }

        private void SpawnEnemy()
        {
            if (Time.time > 60)
            {
                float yPosition1 = Random.Range(1, 3.5f);
                float yPosition2 = Random.Range(-3.5f,-1);
                int randomEnemy1 = Random.Range(0, enemyPrefabs.Length);
                int randomEnemy2 = Random.Range(0, enemyPrefabs.Length);
                Instantiate(enemyPrefabs[randomEnemy1], new Vector2(transform.position.x, yPosition1), Quaternion.identity);
                Instantiate(enemyPrefabs[randomEnemy2], new Vector2(transform.position.x, yPosition2), Quaternion.identity);
                return;
            }
            float yPosition = Random.Range(-3.5f, 3.5f);
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomEnemy], new Vector2(transform.position.x, yPosition), Quaternion.identity);
        }

        private IEnumerator spawnEnemyOnTimer(float interval)
        {
            yield return new WaitForSeconds(interval);
            SpawnEnemy();
            StartCoroutine(spawnEnemyOnTimer(interval));
        }
    }
}


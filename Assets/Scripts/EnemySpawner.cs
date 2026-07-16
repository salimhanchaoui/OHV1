using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;      // drag the Enemy prefab here
    public float respawnTime = 5f;      // seconds before a new enemy spawns
    public int maxEnemies = 3;          // max enemies alive at once

    private int currentEnemies = 0;
    private float respawnTimer;

    void Update()
    {
        if (currentEnemies < maxEnemies)
        {
            respawnTimer -= Time.deltaTime;

            if (respawnTimer <= 0f)
            {
                SpawnEnemy();
                respawnTimer = respawnTime;
            }
        }
    }

    void SpawnEnemy()
    {
        // Spawn at the spawner's position
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        currentEnemies++;
    }

    // Call this when an enemy dies
    public void EnemyDied()
    {
        currentEnemies--;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    public EnemyProvider enemyProvider;
    public Transform[] spawnPoints;
    public PlayerStats player;

    public ObstacleProvider groundobstacleProvider;
    public Transform[] groundSpawnPoints;

    public ObstacleProvider airObstacleProvider;
    public Transform[] airSpawnPoints;

    void Start()
    {
        SpawnRandomEnemy();
        SpawnGroundObstacles();
        SpawnAirObstacles();
    }

    private void SpawnRandomEnemy()
    {

        for (int i = 0; i < spawnPoints.Length; i++)
        {

            var enemy = enemyProvider.ProvideEnemy();
            
            var spawnedGoon = Instantiate(enemy, spawnPoints[i].position, Quaternion.identity);
            spawnedGoon.player = player;
        }
    }

    private void SpawnGroundObstacles()
    {
        foreach (var spawnPoint in groundSpawnPoints)
        {
            var groundObstacle = groundObstacleProvider.ProvideObstacle();
            Instantiate(groundObstacle, spawnPoint.position, Quaternion.identity);
        }
    }

    private void SpawnAirObstacles()
    {
        foreach (var spawnPoint in airSpawnPoints)
        {
            var airObstacle = airObstacleProvider.ProvideObstacle();
            Instantiate(airObstacle, spawnPoint.position, Quaternion.identity);
        }
    }
}

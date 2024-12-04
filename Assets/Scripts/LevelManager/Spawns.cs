using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    public EnemyProvider enemyProvider;
    public Transform[] spawnPoints;
    public PlayerStats player;

    void Start()
    {
        SpawnRandomEnemy();
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

}

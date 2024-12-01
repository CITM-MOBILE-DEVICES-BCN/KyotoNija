using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEnemy : Enemy
{
    [SerializeField] private FlyingFella enemyPrefab;

    [SerializeField] private float spawnTimer;
    private float maxSpawnTime;

    private void Start()
    {
        maxSpawnTime = spawnTimer;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0)
        {
            spawnTimer = maxSpawnTime;
            var enemy = Instantiate(enemyPrefab);
            enemy.transform.position = transform.position;
            enemy.player = player;
        }

    }
}

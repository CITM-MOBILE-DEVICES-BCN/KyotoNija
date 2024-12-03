using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPool;
    public Transform[] spawnPoints;
    Difficulty gameDifficulty;
    void Start()
    {
        gameDifficulty = GameManager.Instance.gameDifficulty;
        int maxEnemiesToChooseFrom = CalculateMaxEnemies(gameDifficulty);

        SpawnRandomEnemy(maxEnemiesToChooseFrom);
    }

    private void SpawnRandomEnemy(int maxEnemiesToChooseFrom)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (enemyPool.Count == 0 || maxEnemiesToChooseFrom <= 0) return;
            Debug.Log("Spawning enemy");
            int enemyIndex = Random.Range(0, maxEnemiesToChooseFrom);
            Instantiate(enemyPool[enemyIndex], spawnPoints[i].position, Quaternion.identity);
        }
    }

    private int CalculateMaxEnemies(Difficulty gameDifficulty)
    {
        if (gameDifficulty == Difficulty.BABY)
        {
            return 2;
        }
        else if (gameDifficulty == Difficulty.EASY)
        {
            return 3;
        }
        else if (gameDifficulty == Difficulty.HARDER)
        {
            return 4;
        }
        else if (gameDifficulty == Difficulty.HERALD_OF_CHAOS)
        {
            return 5;
        }
        else
        {
            return enemyPool.Count;
        }
    }
}

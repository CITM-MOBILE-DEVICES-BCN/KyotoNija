
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyProvider", menuName = "EnemyProvider")] 
public class EnemyProvider : ScriptableObject
{
    public Enemy[] enemyPrefabs;
    public Enemy ProvideEnemy()
    {

        var difficulty = GameManager.Instance.gameDifficulty;

        switch (difficulty)
        {
            case Difficulty.BABY:
                return enemyPrefabs[Random.Range(0, 2)];
                break;
            case Difficulty.EASY:
                return enemyPrefabs[Random.Range(0, 3)];
                break;
            case Difficulty.MEDIUM:
                return enemyPrefabs[Random.Range(0, 3)];
                break;
            case Difficulty.HARD:
                return enemyPrefabs[Random.Range(0, 4)];
                break;
            case Difficulty.HARDER:
                return enemyPrefabs[Random.Range(0, 4)];
                break;
            case Difficulty.HERALD_OF_CHAOS:
                return enemyPrefabs[Random.Range(0, enemyPrefabs.Count())];
                break;
            default:
                return enemyPrefabs[Random.Range(0, enemyPrefabs.Count())];
                break;


        }
    }

}

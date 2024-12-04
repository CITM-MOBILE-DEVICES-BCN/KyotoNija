using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleProvider", menuName = "ObstacleProvider")]
public class BaseObstacleProvider : ScriptableObject
{
    public GameObject[] obstaclePrefabs; // Array of obstacle prefabs

    public GameObject ProvideObstacle()
    {
        var difficulty = GameManager.Instance.gameDifficulty;

        switch (difficulty)
        {
            case Difficulty.BABY:
                return obstaclePrefabs[Random.Range(0, 2)]; // First 2 obstacles
            case Difficulty.EASY:
                return obstaclePrefabs[Random.Range(0, 3)]; // First 3 obstacles
            case Difficulty.MEDIUM:
                return obstaclePrefabs[Random.Range(0, 3)];
            case Difficulty.HARD:
                return obstaclePrefabs[Random.Range(0, 4)];
            case Difficulty.HARDER:
                return obstaclePrefabs[Random.Range(0, 4)];
            case Difficulty.HERALD_OF_CHAOS:
                return obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]; // All obstacles
            default:
                return obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinisher : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.OnLevelFinished();
            GameManager.instance.LoadScene("RobotinMeta");
            GameManager.instance.currentLevel.timerManager.ResetTimer();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField] protected int damage = 1; // Default damage dealt by the obstacle

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.SendMessage("DamageDealt");
            }
        }
    }
}

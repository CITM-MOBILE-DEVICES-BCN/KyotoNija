using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCloud : Obstacle
{
    [Header("Poison Cloud Settings")]
    [SerializeField] private float duration = 5f;
    [SerializeField] private bool isIndefinite = false; // Whether the cloud lasts indefinitely


    private bool hasDealtDamage = false;

    void Start()
    {
        // Destroy the cloud after the specified duration unless it is indefinite
        if (!isIndefinite)
        {
            Destroy(gameObject, duration);
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasDealtDamage && collision.gameObject.CompareTag("Player"))
        {
            PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.SendMessage("DamageDealt");
                hasDealtDamage = true;
            }
        }
    }
}

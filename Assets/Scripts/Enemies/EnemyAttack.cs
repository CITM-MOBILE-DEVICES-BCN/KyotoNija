using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HitWhen
{
    STILL,
    ALWAYS
}



public class EnemyAttack : MonoBehaviour
{
    public HitWhen hitType;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerStats>();
        if (player)
        {
            player.ReceiveDamage(hitType);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerStats>();
        if (player)
        {
            player.ReceiveDamage(hitType);
        }
    }
}

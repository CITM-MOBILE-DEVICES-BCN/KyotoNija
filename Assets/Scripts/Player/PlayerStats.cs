using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int hp;

    private bool iFrames = false;

    private SpriteRenderer renderer;
    private Rigidbody2D rb;
    private PlayerMovement movement;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.red;
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
    }

    private void DamageDealt()
    {
        if (!iFrames)
        {
            hp--;
            movement?.GetPlayerOffWall();
            iFrames = true;
            renderer.color = Color.green;
            if(hp  <= 0)
            {
                print("dead");
            }

            //rb.velocity *= -1;
            Invoke("DeactivateIFrames", 1.2f);
        }
    }

    private void DeactivateIFrames()
    {
        renderer.color = Color.red;
        iFrames = false;
    }

    public void ReceiveDamage(HitWhen hitInfo)
    {
        if(hitInfo == HitWhen.STILL && rb.velocity.magnitude < 1)
        {
            DamageDealt();
        }
        else if (hitInfo == HitWhen.ALWAYS && rb.velocity.magnitude > 1)
        {
            DamageDealt();
        }
    }

}

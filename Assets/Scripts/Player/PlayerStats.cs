using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int hp;

    private bool iFrames = false;

    private SpriteRenderer renderer;
    private Rigidbody2D rb;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.red;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (!iFrames)
        //{
        //    hp--;
        //    iFrames = true;
        //    renderer.color = Color.green;
        //    //rb.velocity *= -1;
        //    Invoke("DeactivateIFrames", 1.2f);
        //}
    }

    private void DamageDealt()
    {
        if (!iFrames)
        {
            hp--;
            iFrames = true;
            renderer.color = Color.green;
            //rb.velocity *= -1;
            Invoke("DeactivateIFrames", 1.2f);
        }
    }

    void DeactivateIFrames()
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

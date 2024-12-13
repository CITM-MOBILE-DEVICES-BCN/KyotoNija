using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing;
using UnityEngine;
using MyNavigationSystem;

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
            if (hp <= 0)
            {
                AudioManager.instance.PlayDeathSound();
                print("dead");
                AudioManager.instance.PlayTitleMusic();
                NavigationManager.Instance.LoadScene("MainMenu_1");
            }
            else
            {
                AudioManager.instance.PlayDamageSound();
                Invoke("DeactivateIFrames", 1.2f);
            }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MainCamera"))
        {
            AudioManager.instance.PlayDeathSound();
            AudioManager.instance.PlayTitleMusic();
            NavigationManager.Instance.LoadScene("MainMenu_1");
        }
    }

}

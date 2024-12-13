using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing;
using UnityEngine;
using MyNavigationSystem;



public class PlayerStats : MonoBehaviour
{
    public int hp;

    private bool iFrames = false;

    public SpriteRenderer renderer;
    private Rigidbody2D rb;
    private PlayerMovement movement;

    public Animator playeranimator;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.green;
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
            playeranimator.SetTrigger("Hurt");
            Color currentColor = renderer.color;
            renderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.0f);

            Debug.Log("Player hit");
            if (hp <= 0)
            {
                print("dead");
                AudioManager.instance.PlayDeathSound();
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
        renderer.color = Color.green;
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

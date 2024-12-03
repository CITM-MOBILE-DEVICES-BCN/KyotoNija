using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhonyPlayer : ShootyEnemy
{
    private Rigidbody2D rb;
    [SerializeField] float force = 5f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    protected void ImpulseToDirection(Vector3 dashDirection)
    {

        if (dashDirection.magnitude > .1f)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(dashDirection * force, ForceMode2D.Impulse);
            Debug.Log(dashDirection.magnitude);
        }

    }

    private void Update()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0)
        {
            ImpulseToDirection((crosshair.transform.position - transform.position).normalized);
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
        }
    }

    protected void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
        }
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.gravityScale = 1;
        }
    }
}

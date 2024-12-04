using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float force = 5f;
    [SerializeField] public int money = 0;
    Vector3 startMousePos;
    Vector3 endMousePos;
    Vector3 dashDir;
    Vector2 direction;
    Ray test;
    Ray velocityRayTest;

    public float timescale = 0.25f;
    float dashTimer;
    public float dashTimeLimit = 3;
    int jumps = 2;
    public int jumpsAmount = 2;
    public bool canClingToWall = true;
    bool isOnWall;
    public int luckMultiplayer;      

    PowerUpModifier powerUpModifier;

    private void Start()
    {        
        powerUpModifier = new PowerUpModifier();
        jumpsAmount = powerUpModifier.Dash();
        timescale = powerUpModifier.TimeStop();
        dashTimeLimit = powerUpModifier.DashTime();
        luckMultiplayer = powerUpModifier.Luck();
        canClingToWall = true;
        jumps = jumpsAmount;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && jumps > 0)
        {
            startMousePos = Input.mousePosition;
            startMousePos.z = Camera.main.GetComponent<Transform>().position.z;
            startMousePos = Camera.main.ScreenToWorldPoint(startMousePos);
            dashTimer = dashTimeLimit;
        }

        if (Input.GetMouseButton(0) && dashTimer > 0 && jumps > 0 && !isOnWall)
        {
            SlowTimeSpeed();
            dashTimer -= Time.unscaledDeltaTime;
        }

        if (dashTimer < 0)
        {
            ResumeTimeSpeed();
            if (isOnWall)
            {
                jumps--;
            }
            dashTimer = dashTimeLimit;
        }

        if (Input.GetMouseButtonUp(0)){
            print("button");
        }

        
        if (Input.GetMouseButtonUp(0) && dashTimer > 0 && jumps > 0)
        {
            dashDir = Input.mousePosition;
            dashDir.z = Camera.main.GetComponent<Transform>().position.z;
            dashDir = Camera.main.ScreenToWorldPoint(dashDir);
            dashDir = (dashDir - startMousePos).normalized;

            if (dashDir.magnitude > .1f)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(dashDir * force, ForceMode2D.Impulse);
            }

            ResumeTimeSpeed();
            canClingToWall = true;
            jumps--;
            dashTimer = dashTimeLimit;
        }

        endMousePos = Input.mousePosition;
        endMousePos.z = Camera.main.GetComponent<Transform>().position.z;
        endMousePos = Camera.main.ScreenToWorldPoint(endMousePos);
        Debug.Log(jumps);   
    }
    void ResumeTimeSpeed()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }
    void SlowTimeSpeed()
    {
        Time.timeScale = timescale;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
    public void GetPlayerOffWall()
    {
        canClingToWall = false;
        rb.gravityScale = 1;
        jumps = jumpsAmount;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") && canClingToWall == true)
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
            jumps = jumpsAmount;
            isOnWall = true;
        }
        if (collision.gameObject.CompareTag("IceWall") && canClingToWall == true)
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0.25f;
            jumps = jumpsAmount;
            isOnWall = true;
        }
        if (collision.gameObject.CompareTag("BounceWall") && canClingToWall == true)
        {
            jumps = jumpsAmount;
        }        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.gravityScale = 1;
            isOnWall = false;
        }
        if (collision.gameObject.CompareTag("IceWall"))
        {
            rb.gravityScale = 1;
            isOnWall = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position - (startMousePos - endMousePos));
        test.direction = direction;
        test.origin = transform.position;
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(test);
        Gizmos.color = Color.yellow;
        velocityRayTest.direction = rb.velocity;
        velocityRayTest.origin = transform.position;
        Gizmos.DrawRay(velocityRayTest);
    }
}
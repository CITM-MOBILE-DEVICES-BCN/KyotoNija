 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float force = 5f;
    [SerializeField] public int money = 0;
    [SerializeField] TrailRenderer trail;
    Vector3 startMousePos;
    Vector3 endMousePos;
    Vector3 dashDir;
    Vector2 direction;
    Ray test;
    Ray velocityRayTest;
    public Animator playeranimator;
    public float timescale = 0.25f;
    float dashTimer;
    int moveInput;  
    public float dashTimeLimit = 3;
    int jumps = 2;
    public int jumpsAmount = 2;
    public bool canClingToWall = true;
    bool isOnWall;
    public int luckMultiplayer;
    public CircleCollider2D coinCollector;
    private bool isOnBegining = false;
    //Temporal Power Up
    int selectorTPU; 
    bool activeTPU = false;
    float timerTPU;

    PowerUpModifier powerUpModifier;
    

    private void Awake()
    {

    }

    void Start()
    {
        moveInput = 0;
       powerUpModifier = new PowerUpModifier();
        powerUpModifier.Start();
        jumpsAmount += powerUpModifier.Dash();
        timescale += powerUpModifier.TimeStop() * (-0.02f);
        dashTimeLimit += powerUpModifier.DashTime() * 0.25f;
        luckMultiplayer += powerUpModifier.Luck();
        coinCollector.radius += powerUpModifier.CoinCollection();
        canClingToWall = true;
        jumps = jumpsAmount;

        if (trail != null)
        {
            trail.emitting = false;
        }
    }
    void Update()
    {
        if(isOnWall && !isOnBegining)
        {
            playeranimator.SetBool("Dashing", false);
            playeranimator.SetBool("Wall", true);
            playeranimator.SetBool("Idle", false);
            Debug.Log("ISONWall");
        }
       if (!isOnWall && isOnBegining)
        {
            playeranimator.SetBool("Dashing", false);
            playeranimator.SetBool("Wall", false);
            playeranimator.SetBool("Idle", true);
        }
        if (!isOnWall && !isOnBegining) {
            playeranimator.SetBool("Dashing", true);
            playeranimator.SetBool("Wall", false);
            playeranimator.SetBool("Idle", false);
        } 

        if (rb.velocity.x > 0)
        {
            moveInput = 1;

        }
        else if (rb.velocity.x < 0)
        {
            moveInput = -1; // Moving to the left
        }


        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
   
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
            AudioManager.instance.PlayJumpSound();
            dashDir = Input.mousePosition;
            dashDir.z = Camera.main.GetComponent<Transform>().position.z;
            dashDir = Camera.main.ScreenToWorldPoint(dashDir);
            dashDir = (dashDir - startMousePos).normalized;

            if (dashDir.magnitude > .1f)
            {
                rb.velocity = Vector2.zero;

                if (trail != null)
                {
                    trail.emitting = true;
                }

                rb.AddForce(dashDir * force, ForceMode2D.Impulse);

                StartCoroutine(DisableTrailAfterDash());
            }

            ResumeTimeSpeed();
            canClingToWall = true;
            jumps--;
            dashTimer = dashTimeLimit;
        }   

        if(activeTPU == true)
        {            
            WaitForSeconds.Equals(0, 10); //NOTA: Que despues de unos segundos se desactive, preguntar Pau           
            timerTPU -= 1*Time.deltaTime;
            if (timerTPU <= 0)
            {
                TurnDownTPU();
            }           
        }

        endMousePos = Input.mousePosition;
        endMousePos.z = Camera.main.GetComponent<Transform>().position.z;
        endMousePos = Camera.main.ScreenToWorldPoint(endMousePos);
        Debug.Log(jumps);   
    }
    IEnumerator DisableTrailAfterDash()
    {
        yield return new WaitForSeconds(0.3f); 
        if (trail != null)
        {
            trail.emitting = false;
        }
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
        if (collision.gameObject.CompareTag("BeginWall"))
        {
            rb.gravityScale = 1;;
            isOnBegining = true;
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
        if(collision.gameObject.CompareTag("BeginWall"))
        {
            rb.gravityScale = 1;
            isOnBegining = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TEMPORAL POWER UP ACTIVATION       
        if (collision.gameObject.CompareTag("TemporalPowerUp"))
        {
            if (activeTPU == true)
            {
                TurnDownTPU();
            }
            selectorTPU = Random.Range(0, 4);

            switch (selectorTPU)
            {
                case 0:
                    Debug.Log("DASHES");
                    jumps++;                        //DASHES
                    break;
                case 1:
                    Debug.Log("TIMESCALE");
                    timescale -= 0.05f;             //TIMESCALE
                    break;
                case 2:
                    Debug.Log("LUCK");

                    luckMultiplayer += 25;          //LUCK
                    break;
                case 3:
                    Debug.Log("DASH TIME LIMIT");

                    dashTimeLimit++;                //DASH TIME LIMIT
                    break;
                case 4:
                    Debug.Log("COIN COLLECTOR RADIOUS");
                    coinCollector.radius += 0.25f;  //COIN COLLECTOR RADIOUS
                    break;
            }
            activeTPU = true;
            timerTPU = 10;
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

    void TurnDownTPU()
    {
        switch (selectorTPU)
        {
            case 0:
                jumps--;                        //DASHES
                break;
            case 1:
                timescale += 0.05f;             //TIMESCALE
                break;
            case 2:
                luckMultiplayer -= 25;          //LUCK
                break;
            case 3:
                dashTimeLimit--;                //DASH TIME LIMIT
                break;
            case 4:
                coinCollector.radius -= 0.25f;  //COIN COLLECTOR RADIOUS
                break;
        }
        activeTPU = false;
    }
}
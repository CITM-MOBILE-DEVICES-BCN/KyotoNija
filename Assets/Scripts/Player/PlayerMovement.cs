using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float force = 5f;
    Vector3 startMousePos;
    Vector3 endMousePos;
    Vector3 dashDir;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Input.mousePosition;
            startMousePos.z = Camera.main.GetComponent<Transform>().position.z;
            startMousePos = Camera.main.ScreenToWorldPoint(startMousePos);
        }

        if (Input.GetMouseButton(0))
        {
            Time.timeScale = 0.25f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

        if (Input.GetMouseButtonUp(0))
        {
            
            dashDir = Input.mousePosition;
            dashDir.z = Camera.main.GetComponent<Transform>().position.z;
            dashDir = Camera.main.ScreenToWorldPoint(dashDir);
            dashDir = (dashDir - startMousePos).normalized;

            if (dashDir.magnitude > .1f)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(dashDir * force, ForceMode2D.Impulse);
                Debug.Log(dashDir.magnitude);
            }
           
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
        }
        endMousePos = Input.mousePosition;
        endMousePos.z = Camera.main.GetComponent<Transform>().position.z;
        endMousePos = Camera.main.ScreenToWorldPoint(endMousePos);
        
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
        }
        if (collision.gameObject.CompareTag("IceWall"))
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0.25f;
        }

        //when player hits the bounce wall it will bounce 
        if (collision.gameObject.CompareTag("BounceWall"))
        {
            var speed = rb.velocity.magnitude;
            var direction = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
            rb.AddForce(direction * Mathf.Max(speed, 4f),ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
        }
        if (collision.gameObject.CompareTag("IceWall"))
        {
            rb.gravityScale = 0.25f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.gravityScale = 1;
        }
        if (collision.gameObject.CompareTag("IceWall"))
        {
            rb.gravityScale = 1;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position - (startMousePos - endMousePos));
    }

}

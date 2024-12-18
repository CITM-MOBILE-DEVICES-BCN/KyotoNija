using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ROBOTIN
{
    public class JumpPadController : MonoBehaviour
    {
        [SerializeField] public GameObject player;
        [SerializeField] public int a;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && player.activeInHierarchy)
            {
                Jump();
            }
        }

        private void Jump()
        {
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            Vector2 direction = new Vector2(1, 2).normalized;
            rb.AddForce(direction * rb.velocity.magnitude * 5, ForceMode2D.Impulse);

        }

        private void Update()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            a = 10;
            Debug.Log(player.gameObject.name);

            if (Input.GetKey(KeyCode.Backspace))
            {
                Jump();
            }
        }
    }
}

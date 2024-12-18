using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ROBOTIN
{
    public class MovingPlatform : MonoBehaviour
    {
        float speed = 1.5f;
        Vector3 startPosition;
        Vector3 endPosition = new Vector3(5, 0, 0);
        bool movingRight = true;
        [SerializeField] private GameObject player;

        void Start()
        {
            startPosition = transform.position;
        }

        void Update()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Vector3 movement = Vector3.zero;

            if (movingRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                if (transform.position.x >= endPosition.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                if (transform.position.x <= startPosition.x)
                {
                    movingRight = true;
                }
            }

            transform.position += movement;

            if (player != null)
            {
                player.transform.position += movement;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                player = collision.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                player = null;
            }
        }
    }
}
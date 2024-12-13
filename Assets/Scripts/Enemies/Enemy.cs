using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Collider2D collider;
    protected Animator animator;

    [SerializeField] private GameObject powerUp;

    public PlayerStats player; // Change this so the enemy provider assigns it
    

    public Direction direction;
    void Awake()
    {
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        if(direction == Direction.LEFT)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }

    internal void OnTriggerEnter2D(Collider2D collision)
    {
        print("something has collided with me");

        var player = collision.GetComponent<PlayerMovement>();
        if (player)
        {
            AudioManager.instance.PlayAttackSound();
            if (Random.Range(0,3) == 0 && powerUp)
            {
                Instantiate(powerUp, transform.position, Quaternion.identity);
            }

            Destroy(this.gameObject);
        }
    }

    protected void FixedUpdate()
    {
        if (player && Vector2.Distance(player.transform.position, transform.position) > 45)
        {
            Destroy(this.gameObject);
        }
    }

}

public enum Direction
{
    LEFT,
    RIGHT
}
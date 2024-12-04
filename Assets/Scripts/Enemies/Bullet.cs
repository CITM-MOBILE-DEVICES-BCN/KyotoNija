using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction; // The direction the bullet moves
    public int shotSpeed = 12; // The speed of the bullet

    // Update is called once per frame
    void Update()
    {
        // Move the bullet in the specified direction
        transform.position += (Vector3)direction * Time.deltaTime * shotSpeed;

        // Rotate the bullet to align with its movement direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // Corrected rotation
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy the bullet on collision
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ShootyEnemy : Enemy
{
    [SerializeField]  private Transform crosshair;
    [SerializeField]  private Bullet bulletPrefab;
    [SerializeField] [Range(0.01f, 0.2f)] private float aimSpeed;

    private float shootTimer = 2.2f;
    private const float SHOOT_TIME = 2.2f;

    private void FixedUpdate()
    {
        Vector2 direction = player.transform.position - crosshair.position;
        direction.Normalize();
        crosshair.position += (Vector3) direction * aimSpeed;

    }
    private void Update()
    {
        shootTimer -= Time.deltaTime;

        if(shootTimer <= 0) 
        {
            var bullet = Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            bullet.direction = (crosshair.position - transform.position).normalized;
            shootTimer = SHOOT_TIME;
        }
    }

}

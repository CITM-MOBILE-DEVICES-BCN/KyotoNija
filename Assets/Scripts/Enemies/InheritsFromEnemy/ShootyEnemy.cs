using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ShootyEnemy : Enemy
{
    [SerializeField] protected Transform crosshair;
    [SerializeField] protected Bullet bulletPrefab;
    [SerializeField] [Range(0.01f, 0.2f)] protected float aimSpeed;

    protected float shootTimer = 2.2f;
    protected const float SHOOT_TIME = 2.2f;

    protected void FixedUpdate()
    {
        base.FixedUpdate();


        if(!player || Vector2.Distance(transform.position, player.transform.position) > 12)
        {
            return;
        }

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
            animator.SetTrigger("Attack");
        }
    }

}

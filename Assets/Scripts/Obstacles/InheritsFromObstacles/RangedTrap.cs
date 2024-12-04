using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedTrap : Obstacle
{
    [Header("Ranged Trap Settings")]
    [SerializeField] private GameObject bulletPrefab; // Prefab for the bullet
    [SerializeField] private Transform firePoint; // Where bullets are spawned
    [SerializeField] private float fireInterval = 2f; // Time between shots
    [SerializeField] private Vector2 fireDirection = Vector2.right; // Direction to fire

    [Header("Trail Settings")]
    [SerializeField] private bool hasTrail = false; // Whether bullets leave a trail
    [SerializeField] private GameObject poisonCloudPrefab; // Poison Cloud prefab
    [SerializeField] private float poisonSpawnInterval = 0.5f; // Interval for spawning poison clouds
    [SerializeField] private float poisonCloudLifetime = 5f; // Lifetime of poison clouds

    private float timeSinceLastShot = 0f;

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= fireInterval)
        {
            FireBullet();
            timeSinceLastShot = 0f;
        }
    }

    private void FireBullet()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Instantiate the bullet
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Set bullet's velocity using Rigidbody2D
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = fireDirection.normalized * 12; // Example speed of 12 units
            }

            // Only spawn poison clouds if hasTrail is enabled
            if (hasTrail)
            {
                StartCoroutine(SpawnPoisonTrail(bullet));
            }

            // Destroy the bullet after a certain time to prevent clutter
            Destroy(bullet, 5f);
        }
    }

    private IEnumerator SpawnPoisonTrail(GameObject bullet)
    {
        while (bullet != null)
        {
            // Spawn a poison cloud at the bullet's position
            if (poisonCloudPrefab != null)
            {
                GameObject poisonCloud = Instantiate(poisonCloudPrefab, bullet.transform.position, Quaternion.identity);

                // Scale poison cloud
                poisonCloud.transform.localScale = Vector3.one * 0.5f; 

                Destroy(poisonCloud, poisonCloudLifetime); // Destroy the poison cloud after its lifetime
            }

            // Wait before spawning the next poison cloud
            yield return new WaitForSeconds(poisonSpawnInterval);
        }
    }
}

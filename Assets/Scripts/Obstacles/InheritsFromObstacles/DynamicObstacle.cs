using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObstacle : Obstacle
{
    [Header("Movement Settings")]
    [SerializeField] private Transform[] waypoints; // Array of points to move through
    [SerializeField] private float speed = 2f; // Movement speed
    [SerializeField] private float tolerance = 0.1f; // Distance threshold for switching to the next point

    [Header("Rotation Settings")]
    [SerializeField] private bool enableRotation = false; // Enable or disable rotation
    [SerializeField] private float rotationSpeed = 50f; // Speed of rotation around Z-axis

    private int currentWaypointIndex = 0; // Tracks the current waypoint

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        if (waypoints == null || waypoints.Length < 2)
        {
            Debug.LogError("At least two waypoints must be assigned.");
            return;
        }

        // Get the current target waypoint
        Transform target = waypoints[currentWaypointIndex];

        // Move towards the target waypoint
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Check if close enough to the waypoint to switch to the next one
        if (Vector3.Distance(transform.position, target.position) <= tolerance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Loop back to the first waypoint
        }
    }

    private void HandleRotation()
    {
        if (enableRotation)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }
}

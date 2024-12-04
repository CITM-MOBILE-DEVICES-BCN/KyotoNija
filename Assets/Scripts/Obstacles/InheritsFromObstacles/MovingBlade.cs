using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlade : Obstacle
{
    [Header("Arm Settings")]
    [SerializeField] private HingeJoint2D armJoint; // Reference to the hinge joint connecting the blade to the arm
    [SerializeField] private bool useMotor = false; // Enable motor for controlled swinging
    [SerializeField] private float motorSpeed = 100f; // Motor speed for controlled swinging
    [SerializeField] private float maxTorque = 1000f; // Maximum torque the motor can apply

    void Start()
    {
        if (armJoint != null && useMotor)
        {
            // Configure the motor for the hinge joint
            JointMotor2D motor = armJoint.motor;
            motor.motorSpeed = motorSpeed;
            motor.maxMotorTorque = maxTorque;
            armJoint.motor = motor;
            armJoint.useMotor = true;
        }
    }

    void Update()
    {
        // Lock the Z-scale to prevent deformation
        Vector3 scale = transform.localScale;
        scale.z = 1f; // Replace with your desired Z-scale value
        transform.localScale = scale;
    }
}
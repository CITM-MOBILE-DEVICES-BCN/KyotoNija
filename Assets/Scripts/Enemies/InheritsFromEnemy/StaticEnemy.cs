using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : Enemy , IAttackable
{
    private PolygonCollider2D frustrum;
    private GameObject frustrumObject;
    private int rotationFrames = 120;
    private const int RESET_ROTATION_FRAMES = 120;

    [SerializeField] [Range(0.1f,1.0f)] private float rotationZ;

    private void Start()
    {
        frustrum = GetComponentInChildren<PolygonCollider2D>();
        frustrumObject = frustrum.gameObject;
    }

    private void FixedUpdate()
    {
        base.FixedUpdate();

        frustrumObject.transform.Rotate(0, 0, rotationZ);
        rotationFrames--;

        if(rotationFrames <= 0)
        {
            rotationFrames = RESET_ROTATION_FRAMES;
            rotationZ *= -1;
        }

    }

    void IAttackable.Attack()
    {
        print("attack for");
        animator.SetTrigger("Attack");
    }
}

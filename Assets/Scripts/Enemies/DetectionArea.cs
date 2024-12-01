using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionArea : MonoBehaviour
{
    private Collider2D collider;

    // Start is called before the first frame update
    void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = transform.parent.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.Attack();
        }

    }
}

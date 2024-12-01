using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingFella : Enemy
{
    [SerializeField] private int movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.position += (Vector3)direction * movementSpeed * Time.deltaTime;
    }
}

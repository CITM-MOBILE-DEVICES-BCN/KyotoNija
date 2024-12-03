using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    private Rigidbody2D rigid;

    public PlayerMovement player;

    public const int distanceParam = 8;

    Vector2 normalSpeed = new Vector2(0, 6);
    Vector2 closeSpeed  = new Vector2(0, 12);

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.y - player.transform.position.y) > distanceParam)
        {
            transform.position += (Vector3)normalSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += (Vector3)closeSpeed * Time.deltaTime;
        }
    }
}

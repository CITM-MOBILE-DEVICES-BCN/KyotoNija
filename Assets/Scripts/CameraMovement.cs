using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class CameraMovement : MonoBehaviour
{
    private Rigidbody2D rigid;

    public PlayerMovement player;

    public const int distanceParam = 8;

    [SerializeField] private TextMeshProUGUI heightLabel;
    private float startingHeight;
    private int currentHeight;


    private void Start()
    {
        startingHeight = transform.position.y;
        GameManager.Instance.SetDifficulty(0);
    }

    [SerializeField] private Vector2 normalSpeed = new Vector2(0, 4);
    [SerializeField] private Vector2 closeSpeed  = new Vector2(0, 10);

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.y - player.transform.position.y) > distanceParam)
        {
            transform.position += (Vector3)normalSpeed * Time.deltaTime;
            print("normal speed");
        }
        else
        {
            transform.position += (Vector3)closeSpeed * Time.deltaTime;
            print("hyper speed");
        }

        currentHeight = (int)(transform.position.y - startingHeight);
        heightLabel.text = currentHeight.ToString();

        if(currentHeight%100 == 0)
        {
            GameManager.Instance.SetDifficulty(currentHeight);
        }

    }
}

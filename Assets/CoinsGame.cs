using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsGame : MonoBehaviour
{
    [SerializeField] private TMP_Text currencyText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.text = "Currency: " + GameManager.Instance.GetCoins() + "+";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTest : MonoBehaviour
{
    public Text currency;

    void Update()
    {
        ActualizarCurrency();
    }

    // Start is called before the first frame update
    public void ActualizarCurrency()
    {
        // Asigna el valor de la variable "Lives" al texto de la UI
        currency.text = "x" + GameManager.Instance.GetCoins();
    }

}

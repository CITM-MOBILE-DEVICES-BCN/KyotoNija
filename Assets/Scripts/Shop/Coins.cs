using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Coins : MonoBehaviour
{


   PowerUpModifier powerUpModifier;

    public int luckMultiplayer;

    private void Start()
    {
        luckMultiplayer = powerUpModifier.Luck();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CoinCollector"))
        {
            int comprobador = Random.Range(0, 100);            
            //CHANCE DE REOGER DOS MONEDAS
            if(comprobador <= luckMultiplayer)
            {
                GameManager.Instance.AddCoins(20);
            }
            else
            {
                GameManager.Instance.AddCoins(10);
                Debug.Log("monedilla");
            }      
            
            Destroy(gameObject);
        }
    }
    
}

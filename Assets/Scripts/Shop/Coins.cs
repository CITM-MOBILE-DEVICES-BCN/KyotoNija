using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Coins : MonoBehaviour
{


   PowerUpModifier powerUpModifier;

    public int luckMultiplayer;
    public ParticleSystem particles;

    private void Start()
    {
        powerUpModifier = new PowerUpModifier();
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
            
            particles.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject,2f);
        }
    }
    
}

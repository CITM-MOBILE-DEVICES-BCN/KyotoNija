using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ROBOTIN
{
    public class ScrewController : MonoBehaviour
    {
        // Define los tipos de screws y sus valores en puntos
        public enum ScrewType { OnePoint, FivePoints }

        [Tooltip("Selecciona el tipo de screw desde el editor")]
        public ScrewType screwType;

        private int screwValue;

        private void Start()
        {
            switch (screwType)
            {
                case ScrewType.OnePoint:
                    screwValue = 1;
                    break;
                case ScrewType.FivePoints:
                    screwValue = 5;
                    break;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if (GameManager.instance.scoreManager != null)
                {
                    GameManager.instance.scoreManager.AddScore(screwValue);
                }

                Destroy(gameObject);
            }
        }
    }
}



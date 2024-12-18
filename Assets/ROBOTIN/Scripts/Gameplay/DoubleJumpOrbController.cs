using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ROBOTIN
{
    public class DoubleJumpOrbController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine(Respawn());

            }
        }

        IEnumerator Respawn()
        {
            yield return null;
            gameObject.SetActive(false);
            yield return new WaitForSeconds(5);
            gameObject.SetActive(true);
        }
    }
}

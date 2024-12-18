using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavigationSystem
{
    public class PopUpSpawn : MonoBehaviour
    {
        [SerializeField] float scaleUpTime = 0.2f;
        [SerializeField] float scaleDownTime = 0.15f;
        [SerializeField] public float dissapearTime = 0.1f;
        [SerializeField] Vector3 initialScale = Vector3.zero;
        [SerializeField] Vector3 maxScale = new Vector3(1.2f, 1.2f, 1.2f);
        [SerializeField] Vector3 finalScale = new Vector3(1f, 1f, 1f);

        public bool isDissapeared = false;

        private void Start()
        {
            StartCoroutine(SpawnAnim());
        }

        private IEnumerator SpawnAnim()
        {
            float elapsedTime = 0f;
            while (elapsedTime < scaleUpTime)
            {
                transform.localScale = Vector3.Lerp(initialScale, maxScale, elapsedTime / scaleUpTime);
                elapsedTime += Time.unscaledDeltaTime; // Usamos tiempo independiente del timeScale
                yield return null;
            }
            transform.localScale = maxScale;

            elapsedTime = 0f;
            while (elapsedTime < scaleDownTime)
            {
                transform.localScale = Vector3.Lerp(maxScale, finalScale, elapsedTime / scaleDownTime);
                elapsedTime += Time.unscaledDeltaTime; // Usamos tiempo independiente del timeScale
                yield return null;
            }
            transform.localScale = finalScale;
        }

        public void DespawnPopUp()
        {
            StartCoroutine(DespawnAnim());
        }

        private IEnumerator DespawnAnim()
        {
            float elapsedTime = 0f;
            while (elapsedTime < dissapearTime)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, elapsedTime / scaleUpTime);
                elapsedTime += Time.unscaledDeltaTime; // Usamos tiempo independiente del timeScale
                yield return null;
            }
            transform.localScale = Vector3.zero;

            isDissapeared = true;
        }
    }
}

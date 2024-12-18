using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ROBOTIN
{
    public class FloodController : MonoBehaviour
    {
        [SerializeField] private float speedPipe = 1.0f;
        [SerializeField] private float dificultyFactor = 0.2f;

        public void Init(int level)
        {
            speedPipe = dificultyFactor * ((level / GameManager.instance.maxLevelsPerLoop) + 1);
        }
        void Update()
        {
            transform.position += Vector3.up * speedPipe * Time.deltaTime;
        }
    }
}
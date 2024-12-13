
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;

namespace MyNavigationSystem
{
    public class PopUpAnimManager : MonoBehaviour
    {
        [Header("Animation Settings")]
        [SerializeField] private float animationDuration = 0.5f;
        [SerializeField] private float animationDelay = 0.2f;

        public void AnimatePopUpScale(List<GameObject> objects)
        {
            StartCoroutine(PlayScaleAnimations(objects));
        }

        private IEnumerator PlayScaleAnimations(List<GameObject> objects)
        {
            
            foreach (GameObject obj in objects)
            {
                if(obj == null)
                {
                    break;
                }
                obj.transform.localScale = Vector3.zero;

                obj.transform.DOScale(Vector3.one, animationDuration).SetEase(Ease.OutBack);

                yield return new WaitForSeconds(animationDuration + animationDelay);
            }
        }
        public void AnimatePopUpWithRotation(List<GameObject> objects)
        {
            StartCoroutine(PlayAnimationsWithRotation(objects));
        }

        private IEnumerator PlayAnimationsWithRotation(List<GameObject> objects)
        {
            foreach (GameObject obj in objects)
            {
                obj.transform.localScale = Vector3.zero;

                obj.transform.rotation = Quaternion.Euler(0, 0, 0);

                obj.transform.DOScale(Vector3.one, animationDuration).SetEase(Ease.OutBack);
                obj.transform.DORotate(new Vector3(0, 0, 360), animationDuration, RotateMode.FastBeyond360).SetEase(Ease.OutBack);

                yield return new WaitForSeconds(animationDuration + animationDelay);
            }
        }




    }
}

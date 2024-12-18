using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ROBOTIN
{
    public class ShopScreen : MonoBehaviour
    {
        [SerializeField] Button backButton;
        [SerializeField] Button itemExample;
        private void Start()
        {
            backButton.onClick.AddListener(OnBackButtonClicked);
            itemExample.onClick.AddListener(OnItemExampleClicked);
        }

        private void OnBackButtonClicked()
        {
            GameManager.instance.UnLoadScreen(gameObject.name);
        }

        private void OnItemExampleClicked()
        {
            // Do something
        }
    }

}
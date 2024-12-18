using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ROBOTIN
{
    public class MetaScreen : MonoBehaviour
    {
        [SerializeField] Button shopButton;
        [SerializeField] Button backToMenuButton;
        [SerializeField] Button world1Button;
        [SerializeField] Button world2Button;
        [SerializeField] Button world3Button;

        [SerializeField] string shopScreen;
        [SerializeField] string world1;
        [SerializeField] string world2;
        [SerializeField] string world3;

        [SerializeField] private TextMeshProUGUI totalScoreText;

        private void Start()
        {
            shopButton.onClick.AddListener(OnShopButtonClicked);
            backToMenuButton.onClick.AddListener(OnBackToMenuButtonClicked);
            world1Button.onClick.AddListener(OnWorld1ButtonClicked);
            world2Button.onClick.AddListener(OnWorld2ButtonClicked);
            world3Button.onClick.AddListener(OnWorld3ButtonClicked);
            totalScoreText.text = GameManager.instance.gameData.GetTotalScore().ToString();

        }

        private void OnShopButtonClicked()
        {
            GameManager.instance.LoadScreen(shopScreen);
        }

        private void OnBackToMenuButtonClicked()
        {
            GameManager.instance.LoadScene("GameSelector");
        }

        private void OnWorld1ButtonClicked()
        {
            GameManager.instance.LoadScreen(world1);
        }

        private void OnWorld2ButtonClicked()
        {
            GameManager.instance.LoadScreen(world2);
        }

        private void OnWorld3ButtonClicked()
        {
            GameManager.instance.LoadScreen(world3);
        }
        //public void SetTotalScoreUI(int value)
        //{
        //    totalScoreText.text = GameManager.instance.gameData.GetTotalScore().ToString();
        //}
    }
}
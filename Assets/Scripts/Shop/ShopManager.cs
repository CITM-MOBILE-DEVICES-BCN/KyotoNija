using MyNavigationSystem;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


public class ShopManager : MonoBehaviour
{
    [SerializeField] private TMP_Text currencyText;

    [Header("Buttons")]
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button purchaseButton1;
    [SerializeField] private Button purchaseButton2;
    [SerializeField] private Button purchaseButton3;
    [SerializeField] private Button purchaseButton4;
    [SerializeField] private Button purchaseButton5;

    [Header("Prices")]
    [SerializeField] private TMP_Text dashPrice;
    [SerializeField] private TMP_Text dashTimePrice;
    [SerializeField] private TMP_Text timeStopPrice;
    [SerializeField] private TMP_Text coinCollectionPrice;
    [SerializeField] private TMP_Text luckPrice;

    [Header("PowerUpLevels")]
    [SerializeField] private TMP_Text dashLevel;
    [SerializeField] private TMP_Text dashTimeLevel;
    [SerializeField] private TMP_Text timeStopLevel;
    [SerializeField] private TMP_Text coinCollectionLevel;
    [SerializeField] private TMP_Text luckLevel;

    [Header("Button Actions")]
    [SerializeField] private string mainMenuSceneId;
    [SerializeField] private int stageTimeStop;    
    
    [Header("ShopIcon")]
    [SerializeField] private Image shopImage;


    void Start()
    {
        List<GameObject> images = new List<GameObject>
        {
            shopImage.gameObject
        };

        NavigationManager.Instance.StartAnim(images, 2);

        mainMenuButton.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(mainMenuSceneId));


        purchaseButton1.onClick.AddListener(() => BuyItem("Dash"));
        purchaseButton2.onClick.AddListener(() => BuyItem("Dash time"));
        purchaseButton3.onClick.AddListener(() => BuyItem("Time stop"));
        purchaseButton4.onClick.AddListener(() => BuyItem("Coin collection"));
        purchaseButton5.onClick.AddListener(() => BuyItem("Luck"));
    }

    private void Update()
    {
        currencyText.text = "Currency: " + GameManager.Instance.GetCoins() + "+";

        dashLevel.text = "Level " + GameManager.Instance.GetLevel(PowerUpLevel.DASHLEVEL);
        dashTimeLevel.text = "Level " + GameManager.Instance.GetLevel(PowerUpLevel.DASHTIMELEVEL);
        timeStopLevel.text = "Level " + GameManager.Instance.GetLevel(PowerUpLevel.TIMESTOPLEVEL);
        coinCollectionLevel.text = "Level " + GameManager.Instance.GetLevel(PowerUpLevel.COINCOLLECTIONLEVEL);
        luckLevel.text = "Level " + GameManager.Instance.GetLevel(PowerUpLevel.LUCKLEVEL);

        dashPrice.text = "Upgrade " + GameManager.Instance.GetPrice(PowerUpPrice.DASHPRICE) + "+";
        dashTimePrice.text = "Upgrade " + GameManager.Instance.GetPrice(PowerUpPrice.DASHTIMEPRICE) + "+";
        timeStopPrice.text = "Upgrade " + GameManager.Instance.GetPrice(PowerUpPrice.TIMESTOPPRICE) + "+";
        coinCollectionPrice.text = "Upgrade " + GameManager.Instance.GetPrice(PowerUpPrice.COINCOLLECTIONPRICE) + "+";
        luckPrice.text = "Upgrade " + GameManager.Instance.GetPrice(PowerUpPrice.LUCKPRICE) + "+";
    }


    void TimeStop()
    {
        //luego poner el if del precio cuando haya dinero

        //TimeScale del playermovment cambiar de 0.25f a 0.20f a 0.15f a 0.10f
        
    }
    void BuyItem(string itemName)
    {
        GameManager.Instance.BuyItem(itemName);
    }


}

using MyNavigationSystem;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button purchaseButton1;
    [SerializeField] private Button purchaseButton2;
    [SerializeField] private Button purchaseButton3;
    [SerializeField] private Button purchaseButton4;
    [SerializeField] private Button purchaseButton5;

    [Header("Button Actions")]
    [SerializeField] private string mainMenuSceneId;
    [SerializeField] private int stageTimeStop;

    void Start()
    {
        mainMenuButton.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(mainMenuSceneId));

        // Configurar botones de compra
        purchaseButton1.onClick.AddListener(() => BuyItem("Dash"));
        purchaseButton2.onClick.AddListener(() => BuyItem("Dash time"));
        purchaseButton3.onClick.AddListener(() => BuyItem("Time stop"));
        purchaseButton4.onClick.AddListener(() => BuyItem("Coin collection"));
        purchaseButton5.onClick.AddListener(() => BuyItem("Luck"));
    }

    void TimeStop()
    {
        //luego poner el if del precio cuando haya dinero

        //TimeScale del playermovment cambiar de 0.25f a 0.20f a 0.15f a 0.10f
        
    }
    void BuyItem(string itemName)
    {
        // Llama a la función de compra del GameManager
        if (GameManager.Instance != null)
        {
            GameManager.Instance.BuyItem(itemName);
        }
        else
        {
            Debug.LogError("GameManager.Instance no está inicializado.");
        }
    }


}

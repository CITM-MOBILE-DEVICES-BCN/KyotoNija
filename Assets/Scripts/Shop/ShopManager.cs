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

    [Header("Button Actions")]
    [SerializeField] private string mainMenuSceneId;
    [SerializeField] private int stageTimeStop;

    void Start()
    {
        mainMenuButton.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(mainMenuSceneId));
    }

    void TimeStop()
    {
        //luego poner el if del precio cuando haya dinero

        //TimeScale del playermovment cambiar de 0.25f a 0.20f a 0.15f a 0.10f
        
    }


}

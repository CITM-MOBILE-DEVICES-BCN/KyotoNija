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


    void Start()
    {
        mainMenuButton.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(mainMenuSceneId));
    }


}

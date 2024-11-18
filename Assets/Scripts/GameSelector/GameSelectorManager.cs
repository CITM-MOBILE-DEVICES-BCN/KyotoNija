using MyNavigationSystem;
using UnityEngine;
using UnityEngine.UI;

public class GameSelectorManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button3;
    [SerializeField] private Button button4;

    [Header("Scene Names in Order")]
    [SerializeField] private string sceneName1;
    [SerializeField] private string sceneName2;
    [SerializeField] private string sceneName3;
    [SerializeField] private string sceneName4;

    private void Start()
    {
        button1.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(sceneName1));
        button2.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(sceneName2));
        button3.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(sceneName3));
        button4.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(sceneName4));
    }
}

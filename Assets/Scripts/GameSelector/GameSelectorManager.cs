using MyNavigationSystem;
using System.Collections.Generic;
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

    private void Awake()
    {
        AudioManager.instance.PlayMenuMusic();
    }

    private void Start()
    {
        button1.onClick.AddListener(() => AudioManager.instance.PlayButtonSound());
        button1.onClick.AddListener(() => AudioManager.instance.PlayTitleMusic());
        button1.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(sceneName1));
        button2.onClick.AddListener(() => AudioManager.instance.PlayButtonSound());
        button2.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(sceneName2));
        button3.onClick.AddListener(() => AudioManager.instance.PlayButtonSound());
        button3.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(sceneName3));
        button4.onClick.AddListener(() => AudioManager.instance.PlayButtonSound());
        button4.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(sceneName4));

        List<GameObject> gameObjects = new List<GameObject>
        {
            button1.gameObject,
            button2.gameObject,
            button3.gameObject,
            button4.gameObject
        };

        NavigationManager.Instance.StartAnim(gameObjects, 1);
    }
}

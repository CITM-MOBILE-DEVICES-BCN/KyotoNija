using MyNavigationSystem;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctionality : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button pauseButton;

    [Header("Button Actions")]
    [SerializeField] private string pauseId;

    private void Start()
    {
        pauseButton.onClick.AddListener(() => AudioManager.instance.PlayButtonSound());
        pauseButton.onClick.AddListener(() => NavigationManager.Instance.ShowPopUp(pauseId));
    }
}

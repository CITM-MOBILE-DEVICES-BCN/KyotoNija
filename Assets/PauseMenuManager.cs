using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public List<GameObject> pauseMenuObjects;


    private void Awake()
    {
        MyNavigationSystem.NavigationManager.Instance.StartAnim(pauseMenuObjects, 1);
    }
}

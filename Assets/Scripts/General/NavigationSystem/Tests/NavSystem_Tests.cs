using System.Collections;
using System.Collections.Generic;
using MyNavigationSystem;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

public class NavSystem_Tests
{
    private NavigationManager navManager;
    private SceneManager mockSceneManager;
    private PopUpManager mockPopUpManager;
    private GameObject navigationSystem;

    [SetUp]
    public void SetUp()
    {
        // Ignorar mensajes de log no críticos durante las pruebas
        LogAssert.ignoreFailingMessages = true;

        // Crear un GameObject para contener el sistema de navegación
        navigationSystem = new GameObject("NavigationSystem");

        // Agregar y configurar el NavigationManager
        navManager = navigationSystem.AddComponent<NavigationManager>();

        // Crear dependencias reales
        mockSceneManager = navigationSystem.AddComponent<SceneManager>();
        mockPopUpManager = navigationSystem.AddComponent<PopUpManager>();

        // Simular un Canvas para el PopUpManager
        GameObject mockCanvas = new GameObject("MockCanvas");
        mockCanvas.AddComponent<Canvas>();

        // Configurar referencias manualmente
        typeof(NavigationManager)
            .GetField("sceneManager", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(navManager, mockSceneManager);

        typeof(NavigationManager)
            .GetField("popUpManager", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(navManager, mockPopUpManager);

        // Simular Awake para inicializar NavigationManager y sus dependencias
        navManager.SendMessage("Awake");
        mockPopUpManager.SendMessage("Awake");
    }

    [UnityTest]
    public IEnumerator NavSystemScenesTest()
    {
        // Cargar una escena del Editor para simular la operación
        var scene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects);
        EditorSceneManager.SetActiveScene(scene);

        // Assert: Verificar que la escena activa se configura correctamente
        Assert.AreEqual(scene.name, navManager.GetCurrentScene());
        yield return null;
    }

    [UnityTest]
    public IEnumerator PopUpSystemHideTest()
    {
        // Preparar un pop-up simulado
        GameObject popUpPrefab = new GameObject("PopUp1");
        typeof(PopUpManager)
            .GetField("popUpPrefabs", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(mockPopUpManager, new List<GameObject> { popUpPrefab });

        // Act: Mostrar y luego ocultar un pop-up
        navManager.ShowPopUp("PopUp1");
        yield return null;
        navManager.HidePopUp("PopUp1");
        yield return null;

        // Assert: Verificar que el pop-up fue eliminado
        Assert.IsTrue(mockPopUpManager.transform.childCount == 0, "El pop-up no fue ocultado correctamente.");
    }

    [TearDown]
    public void TearDown()
    {
        // Destruir los objetos creados durante la prueba
        Object.DestroyImmediate(navigationSystem);
    }
}

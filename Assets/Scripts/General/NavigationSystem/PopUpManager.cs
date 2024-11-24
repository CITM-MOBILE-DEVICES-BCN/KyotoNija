using System.Collections.Generic;
using UnityEngine;

namespace MyNavigationSystem
{
     public class PopUpManager : MonoBehaviour
     {
         [Header("Pop-Up Prefabs")]
         [SerializeField] private List<GameObject> popUpPrefabs;

         private Dictionary<string, GameObject> popUpPrefabDictionary;
         private Dictionary<string, GameObject> activePopUps;

         private void Awake()
         {
             popUpPrefabDictionary = new Dictionary<string, GameObject>();
             activePopUps = new Dictionary<string, GameObject>();

             foreach (var prefab in popUpPrefabs)
             {
                 if (prefab != null)
                 {
                     popUpPrefabDictionary.Add(prefab.name, prefab);
                 }
             }
         }

         public void ShowPopUp(string popUpID)
         {
             if (popUpPrefabDictionary.TryGetValue(popUpID, out var prefab))
             {
                 if (!activePopUps.ContainsKey(popUpID))
                 {
                     Canvas canvas = FindObjectOfType<Canvas>();

                     if (canvas != null)
                     {
                         GameObject instance = Instantiate(prefab, canvas.transform);
                         activePopUps[popUpID] = instance;
                     }
                     else
                     {
                         Debug.LogError("No se encontró ningún Canvas en la escena.");
                     }
                 }
                 else
                 {
                     Debug.LogWarning($"El pop-up con ID '{popUpID}' ya está activo.");
                 }
             }
             else
             {
                 Debug.LogWarning($"Pop-up con ID '{popUpID}' no encontrado en los prefabs.");
             }
         }

         public void HidePopUp(string popUpID)
         {
             if (activePopUps.TryGetValue(popUpID, out var instance))
             {
                 Destroy(instance);
                 activePopUps.Remove(popUpID);
             }
             else
             {
                 Debug.LogWarning($"El pop-up con ID '{popUpID}' no está activo.");
             }
         }
     }
}

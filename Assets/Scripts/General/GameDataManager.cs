using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataManager : MonoBehaviour
{
    private PlayerData playerData = new PlayerData();
    private ItemCollection itemCollection = new ItemCollection();

    private static string dataPath = Path.Combine(Application.persistentDataPath, "PlayerData.json");
    private static string itemsPath = Path.Combine(Application.persistentDataPath, "ItemsData.json");

    private void Awake()
    {
        EnsureDataFilesExist();
        LoadPlayerData();
        LoadItemsData();
    }
    public GameDataManager()
    {

    }

    public int GetCoins()
    {
        return playerData.currency;
    }

    public void AddCoins(int amount)
    {
        playerData.currency += amount;
        SavePlayerData();
    }

    public void BuyItem(string itemName)
    {

        Item item = itemCollection.Items.Find(i => i.Name == itemName);
        if (item == null)
        {
            Debug.LogError($"Item {itemName} no encontrado.");
            return;
        }

        if (playerData.currency >= item.Price)
        {

            playerData.currency -= item.Price;
            item.level++;
            item.Price *= 5;

            UpdatePlayerDataItemLevel(itemName, item.level);

            SavePlayerData();
            SaveItemsData();

            Debug.Log($" {itemName}  upgraded level {item.level}.");
        }
        else
        {
            Debug.Log("You don't have enough currency to buy this upgrade :(.");
        }
    }


    private void EnsureDataFilesExist()
    {
        if (!File.Exists(dataPath))
        {
            playerData = new PlayerData();
            File.WriteAllText(dataPath, JsonUtility.ToJson(playerData, true));
        }

        if (!File.Exists(itemsPath))
        {
            itemCollection = new ItemCollection
            {
                Items = new List<Item>
                {
                    new Item { Name = "Dash", level = 0, Price = 10 },
                    new Item { Name = "Dash time", level = 0, Price = 10 },
                    new Item { Name = "Time stop", level = 0, Price = 10 },
                    new Item { Name = "Coin collection", level = 0, Price = 10 },
                    new Item { Name = "Luck", level = 0, Price = 10 }
                }
            };
            File.WriteAllText(itemsPath, JsonUtility.ToJson(itemCollection, true));
        }
    }

    private void LoadPlayerData()
    {
        string json = File.ReadAllText(dataPath);
        playerData = JsonUtility.FromJson<PlayerData>(json);
    }

    private void LoadItemsData()
    {
        string json = File.ReadAllText(itemsPath);
        itemCollection = JsonUtility.FromJson<ItemCollection>(json);
    }

    private void SavePlayerData()
    {
        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(dataPath, json);
    }

    private void SaveItemsData()
    {
        string json = JsonUtility.ToJson(itemCollection, true);
        File.WriteAllText(itemsPath, json);
    }
    private void UpdatePlayerDataItemLevel(string itemName, int newLevel)
    {
        switch (itemName)
        {
            case "Dash":
                playerData.DashLevel = newLevel;
                break;
            case "Dash time":
                playerData.DashTimeLevel = newLevel;
                break;
            case "Time stop":
                playerData.TimeStopLevel = newLevel;
                break;
            case "Coin collection":
                playerData.CoinCollectionLevel = newLevel;
                break;
            case "Luck":
                playerData.LuckLevel = newLevel;
                break;
            default:
                Debug.LogError($"�tem {itemName} no tiene un nivel asociado en PlayerData.");
                break;
        }
    }

}

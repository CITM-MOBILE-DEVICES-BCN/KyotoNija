using UnityEngine;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    [Header("Currency & Powerups")]
    public int currency = 0;
    public int DashLevel = 0;
    public int DashTimeLevel = 0;
    public int TimeStopLevel = 0;
    public int CoinCollectionLevel = 0;
    public int LuckLevel = 0;
}

[System.Serializable]
public class Item
{
    public string Name;
    public int level;
    public int Price;
}

[System.Serializable]
public class ItemCollection
{
    public List<Item> Items = new List<Item>();
}



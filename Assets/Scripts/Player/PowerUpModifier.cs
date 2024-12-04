using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PowerUpModifier 
{
    static string filePath;
    static string json;
    int dashes;
    float dashTime;
    float timeStop;
    int luck;
    float radious;

    public class PowerUpsData
    {
        public int dashes;
        public float dashTime;
        public float timeStop;
        public float radious;
        public int luck;        
    }

    PowerUpsData loadedData;
   
     public void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "ItemsData.json");
        json = System.IO.File.ReadAllText(filePath);
        loadedData = JsonUtility.FromJson<PowerUpsData>(json);
    }

   public int Dash()
    {
        dashes = loadedData.dashes;
        return dashes;
    }

    public float DashTime()
    {
        dashTime = loadedData.dashTime;
        return dashTime;
    }

    public float TimeStop()
    {
        timeStop = loadedData.timeStop;
        return timeStop;
    }

    public float CoinCollection()
    {
        radious = loadedData.radious;
        return radious;
    }
    //Numero del uno al 100, siendo 100 asegurar recoger dos monedas, y 0 solo recoger 1
    public int Luck()
    {
        luck = loadedData.luck;
        return luck;
    }
}

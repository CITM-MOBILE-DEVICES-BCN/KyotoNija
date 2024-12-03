using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpModifier 
{
    string filePath;
    string json;
    int dashes;
    float dashTime;
    float timeStop;

    public class PowerUpsData
    {
        public int dashes;
        public float dashTime;
        public float timeStop;
        public float coinCollection;
        public float luck;        
    }

    PowerUpsData loadedData;

    private void Start()
    {
        //filePath = Application.dataPath + "/SavedFiles/setting.json";
        //json = System.IO.File.ReadAllText(filePath);

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
        return 0;
    }

    public float Luck()
    {
        return 0;
    }
}

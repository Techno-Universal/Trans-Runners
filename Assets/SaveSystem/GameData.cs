using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[System.Serializable]

public class GameData
{

    public GameManager manager;

    public float level = 0;

    public float player1BestTimeL1 = 0;
    public float player2BestTimeL1 = 0;

    public List<PlayerData> playerTimes = new List<PlayerData>();

    public List<PlayerData> currentPlayers = new List<PlayerData>();
    public void AddStage(int stageValue)
    {
        level += stageValue;
    }
   
    public void ResetData()
    {
        Debug.Log("Save Data Reset!");
        player1BestTimeL1 = 0;
        player2BestTimeL1 = 0;
        level = 0;
    }
    public void SetTimes()
    {
        Debug.Log("Times Set...");
        player1BestTimeL1 = GameManager.p1RecordTime;
        player2BestTimeL1 = GameManager.p2RecordTime;
        player2BestTimeL1 = 0;
        manager.altp1RecordTime = GameManager.p1RecordTime;
        manager.altp2RecordTime = GameManager.p2RecordTime;
    }
    public void LoadTimes()
    {
        Debug.Log("Times loaded...");
        manager.altp1RecordTime = player1BestTimeL1;
        manager.altp2RecordTime = player2BestTimeL1;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.MemoryProfiler;
using UnityEngine;

[System.Serializable]

public class GameData
{

    public GameManager manager;

    public float level = 0;

    public float player1BestTimeL1 = 0;
    public float player2BestTimeL1 = 0;

   

    public float altp1RecordTime;
    public float altp2RecordTime;



    public List<PlayerData> playerTimes = new List<PlayerData>();

    public List<PlayerData> currentPlayers = new List<PlayerData>();
    public void AddStage(int stageValue)
    {
        level += stageValue;
    }
   
    public void ResetData()
    {
        player1BestTimeL1 = 0;
        player2BestTimeL1 = 0;
        level = 0;
    }
    public void SetTimes()
    {
        GameManager.p1RecordTime = altp1RecordTime;
        GameManager.p2RecordTime = altp2RecordTime;
        player1BestTimeL1 = altp1RecordTime;
        player2BestTimeL1 = altp2RecordTime;
    }
}

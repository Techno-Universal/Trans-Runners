using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[System.Serializable]

public class GameData
{

    //public GameManager manager;

    public float level = 0;

    public float player1BestTimeL1 = 0;
    public float player2BestTimeL1 = 0;

    //public List<PlayerData> playerTimes = new List<PlayerData>();

    //public List<PlayerData> currentPlayers = new List<PlayerData>();
    public void AddStage(int stageValue)
    {
        level += stageValue;
    }
   
    
}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[System.Serializable]

public class GameData
{

    public int level = 0;

    public int[] player1BestTimeL1 = new int[0];
    public int[] player2BestTimeL1 = new int[0];

    public List<PlayerData> playerTimes = new List<PlayerData>();

    public List<PlayerData> currentPlayers = new List<PlayerData>();
    public void AddStage(int stageValue)
    {
        level += stageValue;
    }
   
}

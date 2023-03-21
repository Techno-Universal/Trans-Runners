using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[System.Serializable]

public class GameData : MonoBehaviour
{

    public int[] level = new int[0];

    public int[] player1BestTimeL1 = new int[0];
    public int[] player2BestTimeL1 = new int[0];

    public List<PlayerData> playerTImes = new List<PlayerData>();
    public void AddStage(int stageValue)
    {
        level[0] += stageValue;
    }
    public void ResetData()
    {
        level[0] = 0;
    }

    public void FillTempLIst()
    {
        PlayerData data = new PlayerData();
        
       
    }
    public void FillSaveData()
    {
        for(int i = 0; i < 10; i++)
        {
            PlayerData data = new PlayerData();
        }
    }
    public void SortFunc() 
    { 
    
    }
}

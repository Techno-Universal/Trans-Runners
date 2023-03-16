using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int level = 0;

    public int player1BestTimeL1;
    public int player2BestTimeL1;

    public void AddStage(int stageValue)
    {
        level += stageValue;
    }
    public void ResetData()
    {
        level = 0;
    }
}

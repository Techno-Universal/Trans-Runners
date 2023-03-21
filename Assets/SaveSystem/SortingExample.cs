using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SortingExample : MonoBehaviour
{
   
    public List<PlayerData> players = new List<PlayerData>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  players.Sort(SortFunc);
    }
    /*int SortFunc(PlayerData a, PlayerData b)
    {
        if (a.player1BestTimeL1 > b.player1BestTimeL1)
        {
            return -1;
        }
        else if (a.player1BestTimeL1 < b.player1BestTimeL1)
        {
            return +1;
        }
        else
        {
            return 0;
        }

    }*/
}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class GameController : MonoBehaviour
{
    public bool player1Finish;
    public bool player2Finish;

    public bool twoPlayers;

    public float player1FinishTime;
    public float player2FinishTime;

    public List<GameObject> players;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void TwoPlayers(bool value)
    {
        if (value == true)
        {
            twoPlayers = false;
        }
        else
        {
            twoPlayers = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckForClosestPlayer()
    {
        Debug.Log("Checking for players...");


    }
    public void P1Finish()
    {

    }
    public void P2Finish()
    {

    }
}

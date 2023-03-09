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

    public float player1Time;
    public float player2Time;

    public List<GameObject> players;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckForClosestPlayer()
    {
        Debug.Log("Checking for players...");


    }
}

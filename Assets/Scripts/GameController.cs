using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime;
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

    public PauseScreenOpener pause1;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        pause1.ESCOn();
        Debug.Log("Starting...");
        GetComponent<GameManager>();
        if (twoPlayers ==  false)
        {
            gameManager.OnePlayer();
            Debug.Log("YES!!");
        }
    }
    public void TwoPlayers(bool value)
    {
        if (value == true)
        {
            Debug.Log("ON");
            twoPlayers = true;
        }
        else
        {
            Debug.Log("OFF");
            twoPlayers = false;
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

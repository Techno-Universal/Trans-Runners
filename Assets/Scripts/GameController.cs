using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool player1Finish = false;
    public bool player2Finish = false;

    public static bool twoPlayers;

    public string player1FinishTime;
    public string player2FinishTime;

    public float player1FinishTimeNumber;
    public float player2FinishTimeNumber;

    public List<GameObject> players;

    public PauseScreenOpener pause1;

    public GameManager gameManager;

    public AudioSource musicMan;

    // Start is called before the first frame update
    void Start()
    {
        player1Finish = false;
        player2Finish = false;
    }
    public void TwoPlayers(bool value)
    {
        if (value == true)
        {
            Debug.Log("ON");
            GameController.twoPlayers = true;
        }
        else
        {
            Debug.Log("OFF");
            GameController.twoPlayers = false;
        }
    }
    void OnEnable()
    {
        Debug.Log("On Enable...");
        pause1.ESCOn();
        Debug.Log("Starting...");
        GetComponent<GameManager>();
        //player1Finish = false;
        //player2Finish = false;
        if (GameController.twoPlayers == false)
        {
            gameManager.OnePlayer();
            Debug.Log("YES!!");
        }
        if (GameController.twoPlayers == true)
        {
            Debug.Log("TWO!!");
        }
        musicMan.Play();
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
    public void StopMusic()
    {
        musicMan.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    GameData saveData = new GameData();

    Timer tim;

    public GameController controller;

    public CanvasGroup resultGroup;

    public GameObject levelCompleteScreen;

    public GameManager manager;

    public PauseScreenOpener pauseO;

    public GameObject player1finish;

    public GameObject player2finish;

    public InLevelUI levelUI;

    // Start is called before the first frame update
    void Start()
    {
        //player1finish = GameObject.Find("Player1finish");

        //player2finish = GameObject.Find("Player2finish");
    }

    // Update is called once per frame
    void Update()
    {
        if (player1finish == true)
        {
            Debug.Log("P1F");
        }
        if (player2finish == true)
        {
            Debug.Log("P2F");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            Debug.Log("Player1 Finish");
            player1finish.gameObject.SetActive(true);
            controller.player1Finish = true;
            controller.P1Finish();
            if (controller.player1Finish == true && controller.player2Finish == true)
            {
                Debug.Log("FINISH1");
                levelUI.levelComplete = true;
                player1finish.gameObject.SetActive(false);
                player2finish.gameObject.SetActive(false);
                tim.StopTimer();
                levelCompleteScreen.gameObject.SetActive(true);
                pauseO.ESCOff();
            }
            if (controller.twoPlayers == false)
            {
                levelUI.levelComplete = true;
                player1finish.gameObject.SetActive(false);
                player2finish.gameObject.SetActive(false);
                tim.StopTimer();
                levelCompleteScreen.gameObject.SetActive(true);
                pauseO.ESCOff();
            }
        }
        if (other.tag == "Player2")
        {
            Debug.Log("Player2 Finish");
            player2finish.gameObject.SetActive(true);
            controller.player2Finish = true;
            controller.P2Finish();
            if (controller.player1Finish == true && controller.player2Finish == true)
            {
                Debug.Log("FINISH2");
                levelUI.levelComplete = true;
                player1finish.gameObject.SetActive(false);
                player2finish.gameObject.SetActive(false);
                tim.StopTimer();
                levelCompleteScreen.gameObject.SetActive(true);
                pauseO.ESCOff();
            }
        }
        manager.AutoSave();


    }
    

}

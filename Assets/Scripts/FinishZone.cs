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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            Debug.Log("Player1 Finish");
            controller.player1Finish = true;
            controller.P1Finish();
            if (controller.player1Finish == true && controller.player2Finish == true)
            {
                tim.StopTimer();
                levelCompleteScreen.gameObject.SetActive(true);
                pauseO.ESCOff();
            }
        }
        if (other.tag == "Player2")
        {
            Debug.Log("Player2 Finish");
            controller.player2Finish = true;
            controller.P2Finish();
            if (controller.player1Finish == true && controller.player2Finish == true)
            {
                tim.StopTimer();
                levelCompleteScreen.gameObject.SetActive(true);
                pauseO.ESCOff();
            }
        }
        manager.AutoSave();


    }
    

}

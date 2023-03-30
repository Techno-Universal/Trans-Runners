using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    GameData saveData = new GameData();

    Timer tim;

    GameController controller;

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
        pauseO.ESCOff();
        if (other.tag == "Player1")
        {
            controller.player1Finish = true;
            controller.P1Finish();
            if (controller.player1Finish == true && controller.player2Finish == true)
            {
                tim.StopTimer();
                levelCompleteScreen.gameObject.SetActive(true);
            }
        }
        if (other.tag == "Player2")
        {
            controller.player2Finish = true;
            controller.P2Finish();
            if (controller.player1Finish == true && controller.player2Finish == true)
            {
                tim.StopTimer();
                levelCompleteScreen.gameObject.SetActive(true);
            }
        }
        manager.AutoSave();


    }
    

}

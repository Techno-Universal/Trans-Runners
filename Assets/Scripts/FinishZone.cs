using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    GameData saveData = new GameData();

    public Timer tim;

    public GameController controller;

    public CanvasGroup resultGroup;

    public GameObject levelCompleteScreen;

    public GameManager manager;

    public PauseScreenOpener pauseO;

    public GameObject player1finish;

    public GameObject player2finish;

    public InLevelUI levelUI;

    public CharacterMovement1 c1;

    public CharacterMovement2 c2;

    public GameObject p2FTUI1;
    public GameObject p2FTUI2;

    public GameObject pScreen;

    public GameData gData;

    // Start is called before the first frame update
    void Start()
    {
        //player1finish = GameObject.Find("Player1finish");

        //player2finish = GameObject.Find("Player2finish");
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.player1Finish == true)
        {
            Debug.Log("P1F");
        }
        if (controller.player2Finish == true)
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
            c1.Finish1();
            controller.P1Finish();
            controller.player1FinishTime = tim.displayTime;
            controller.player1FinishTimeNumber = tim.currentTime;
            if (controller.player1Finish == true && controller.player2Finish == true)
            {
                Debug.Log("FINISH1");
                pauseO.escOn = false;
                controller.StopMusic();
                levelUI.AllPlayersFInished();
                player1finish.gameObject.SetActive(false);
                player2finish.gameObject.SetActive(false);
                tim.StopTimer();
                levelCompleteScreen.gameObject.SetActive(true);
                GameManager.instance.SetTimes();
                manager.AutoSave();
                Destroy(pScreen.gameObject);
            }
            if (GameController.twoPlayers == false)
            {
                pauseO.escOn = false;
                levelUI.AllPlayersFInished();
                controller.StopMusic();
                player1finish.gameObject.SetActive(false);
                player2finish.gameObject.SetActive(false);
                tim.StopTimer();
                levelCompleteScreen.gameObject.SetActive(true);
                p2FTUI1.gameObject.SetActive(false);
                p2FTUI2.gameObject.SetActive(false);
                controller.player1FinishTime = tim.displayTime;
                GameManager.instance.SetTimes();
                manager.AutoSave();
                Destroy(pScreen.gameObject);
            }
        }
        if (other.tag == "Player2")
        {
            Debug.Log("Player2 Finish");
            player2finish.gameObject.SetActive(true);
            controller.player2Finish = true;
            c2.Finish2();
            controller.P2Finish();
            controller.player2FinishTime = tim.displayTime;
            controller.player2FinishTimeNumber = tim.currentTime;
            if (controller.player1Finish == true && controller.player2Finish == true)
            {
                Debug.Log("FINISH2");
                pauseO.escOn = false;
                controller.StopMusic();
                levelUI.AllPlayersFInished();
                player1finish.gameObject.SetActive(false);
                player2finish.gameObject.SetActive(false);
                tim.StopTimer();
                levelCompleteScreen.gameObject.SetActive(true);
                GameManager.instance.SetTimes();
                manager.AutoSave();
                Destroy(pScreen.gameObject);
            }
        }


    }
    

}

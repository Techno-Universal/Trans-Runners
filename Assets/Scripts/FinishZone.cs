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

    public static GameManager manager;

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
        Debug.Log("Enter...");
        if (other.tag == "Player1")
        {
            if (controller.player1Finish == false)
            {
                Debug.Log("Player1 Finish");
                player1finish.gameObject.SetActive(true);
                controller.player1FinishTime = tim.displayTime;
                controller.player1FinishTimeNumber = tim.currentTime;
                controller.player1Finish = true;
                c1.Finish1();
                controller.P1Finish();
            }
            if (controller.player2Finish == true)
            {
                controller.player1FinishTime = tim.displayTime;
                controller.player1FinishTimeNumber = tim.currentTime;
            }
            if (controller.player1Finish == true && controller.player2Finish == true)
            {
                Debug.Log("FINISH1");
                pauseO.escOn = false;
                controller.player1FinishTime = tim.displayTime;
                controller.player1FinishTimeNumber = tim.currentTime;
                controller.StopMusic();
                levelUI.AllPlayersFInished();
                Destroy(player1finish);
                Destroy(player2finish);
                tim.StopTimer();
                levelCompleteScreen.gameObject.SetActive(true);
                GameManager.instance.SetTimes();
                manager.AutoSave1();
                manager.AutoSave2();
                Destroy(pScreen.gameObject);
            }
            if (GameManager.twoPlayers == false)
            {
                pauseO.escOn = false;
                controller.player1FinishTime = tim.displayTime;
                controller.player1FinishTimeNumber = tim.currentTime;
                levelUI.AllPlayersFInished();
                controller.StopMusic();
                Destroy(player1finish);
                Destroy(player2finish);
                tim.StopTimer();
                levelCompleteScreen.gameObject.SetActive(true);
                p2FTUI1.gameObject.SetActive(false);
                p2FTUI2.gameObject.SetActive(false);
                controller.player1FinishTime = tim.displayTime;
                GameManager.instance.SetTimes();
                manager.AutoSave1();
                Destroy(pScreen.gameObject);
            }
        }
        if (other.tag == "Player2")
        {
            if (controller.player2Finish == false)
            {
              Debug.Log("Player2 Finish");
              player2finish.gameObject.SetActive(true);
              controller.player2FinishTime = tim.displayTime;
              controller.player2FinishTimeNumber = tim.currentTime;
              controller.player2Finish = true;
              c2.Finish2();
              controller.P2Finish();
            }
            if (controller.player1Finish == true)
            {
                Debug.Log("FINISH22");
                controller.player2FinishTime = tim.displayTime;
                controller.player2FinishTimeNumber = tim.currentTime;
            }
            if (controller.player1Finish == true && controller.player2Finish == true)
            {
                Debug.Log("FINISH2");
                pauseO.escOn = false;
                controller.player2FinishTime = tim.displayTime;
                controller.player2FinishTimeNumber = tim.currentTime;
                controller.StopMusic();
                levelUI.AllPlayersFInished();
                Destroy(player1finish);
                Destroy(player2finish);
                tim.StopTimer();
                levelCompleteScreen.gameObject.SetActive(true);
                GameManager.instance.SetTimes();
                manager.AutoSave1();
                manager.AutoSave2();
                Destroy(pScreen.gameObject);
            }
        }


    }
    

}

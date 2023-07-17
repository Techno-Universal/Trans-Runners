using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class FinishZoneOnline : MonoBehaviourPunCallbacks
{
    //GameData saveData = new GameData();

    public OnlineTimer tim;

    public OnlineGameController controller;

    public CanvasGroup resultGroup;

    public GameObject levelCompleteScreen;

    public static GameManager manager;

    public OnlinePauseScreenOpener pauseO;

    public GameObject player1finish;

    public GameObject player2finish;

    public OnlineUI levelUI;

    public static OnlineCharacterMovement c1;

    public static OnlineCharacterMovement c2;

    //public CharacterMovement2 c2;

    public PhotonView view;

    public GameObject p2FTUI1;
    public GameObject p2FTUI2;

    public GameObject pScreen;

    public GameData gData;

    // Start is called before the first frame update
    void Start()
    {
        //player1finish = GameObject.Find("Player1finish");

        //player2finish = GameObject.Find("Player2finish");

        view = GetComponent<PhotonView>();
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
    [PunRPC]
    public virtual void FinishLineCrossed(string playerTag)
    {
        Debug.Log("Enter...");
        if (playerTag == "Player1")
        {
            if (controller.player1Finish == false)
            {
                Debug.Log("Player1 Finish");
                player1finish.gameObject.SetActive(true);
                controller.player1FinishTimeOnline = tim.displayTime;
                controller.player1FinishTimeNumberOnline = tim.currentTime;
                controller.player1Finish = true;
                c1.FinishOnline1();
                controller.P1Finish();
            }
            if (controller.player2Finish == true)
            {
                controller.player1FinishTimeOnline = tim.displayTime;
                controller.player1FinishTimeNumberOnline = tim.currentTime;
            }
            if (controller.player1Finish == true && controller.player2Finish == true)
            {
                Debug.Log("FINISH1");
                pauseO.escOn = false;
                controller.player1FinishTimeOnline = tim.displayTime;
                controller.player1FinishTimeNumberOnline = tim.currentTime;
                //GameManager.p1RecordTime = controller.player1FinishTimeNumber;
                //GameManager.p2RecordTime = controller.player2FinishTimeNumber;
                controller.StopMusic();
                levelUI.AllPlayersFInished();
                Destroy(player1finish);
                Destroy(player2finish);
                tim.StopTimer();
                levelCompleteScreen.gameObject.SetActive(true);
                GameManager.instance.SetTimes();
                //manager.AutoSave1();
                //manager.AutoSave2();
                Destroy(pScreen.gameObject);
            }
            /*if (GameManager.twoPlayers == false)
            {
                pauseO.escOn = false;
                controller.player1FinishTimeOnline = tim.displayTime;
                controller.player1FinishTimeNumberOnline = tim.currentTime;
                //GameManager.p1RecordTime = controller.player1FinishTimeNumber;
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
                //manager.AutoSave1();
                Destroy(pScreen.gameObject);
            }*/
        }
        if (playerTag == "Player2")
        {
            if (controller.player2Finish == false)
            {
                Debug.Log("Player2 Finish");
                player2finish.gameObject.SetActive(true);
                controller.player2FinishTimeOnline = tim.displayTime;
                controller.player2FinishTimeNumberOnline = tim.currentTime;
                controller.player2Finish = true;
                c2.FinishOnline2();
                controller.P2Finish();
            }
            if (controller.player1Finish == true)
            {
                Debug.Log("FINISH22");
                controller.player2FinishTimeOnline = tim.displayTime;
                controller.player2FinishTimeNumberOnline = tim.currentTime;
            }
            if (controller.player1Finish == true && controller.player2Finish == true)
            {
                Debug.Log("FINISH2");
                pauseO.escOn = false;
                controller.player2FinishTimeOnline = tim.displayTime;
                controller.player2FinishTimeNumberOnline = tim.currentTime;
                //GameManager.p1RecordTime = controller.player1FinishTimeNumberOnline;
                //GameManager.p2RecordTime = controller.player2FinishTimeNumberOnline;
                controller.StopMusic();
                levelUI.AllPlayersFInished();
                Destroy(player1finish);
                Destroy(player2finish);
                tim.StopTimer();
                levelCompleteScreen.gameObject.SetActive(true);
                GameManager.instance.SetTimes();
                //manager.AutoSave1();
                //manager.AutoSave2();
                Destroy(pScreen.gameObject);
            }
        }
    }
   
    private void OnTriggerEnter(Collider playerTag)
    {
        view.RPC("FinishLineCrossed", RpcTarget.All, playerTag.tag);
    }


}

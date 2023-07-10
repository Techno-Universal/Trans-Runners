using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Photon.Pun;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class OnlineGameController : MonoBehaviour
{

    #region
    public static GameManager gameManager;
    #endregion
    public bool player1Finish;
    public bool player2Finish;

    public string player1FinishTime;
    public string player2FinishTime;

    public GameObject player2;
    public GameObject player2Cam;
    public GameObject player2VCam;

    public Camera cam1;

    public float player1FinishTimeNumber;
    public float player2FinishTimeNumber;

    public float player1FinishTimeNumberOnline;
    public float player2FinishTimeNumberOnline;

    public string player1FinishTimeOnline;
    public string player2FinishTimeOnline;

    public PauseScreenOpener pause1;

    public AudioSource musicMan;

    public GameData gData;

    public GameObject nR1;
    public GameObject nR2;

    public OnlineTimer timer;

    public List<GameObject> players;

    // Start is called before the first frame update
    void Start()
    {

    }
    /* private void FixedUpdate()
     {

         if (GameController.twoPlayers == false)
         {
             gameManager.OnePlayer();
             Debug.Log("YES!!");
         }
         if (GameController.twoPlayers == true)
         {
             Debug.Log("TWO!!");
         }
     }*/
    void Awake()
    {
        timer.StartTimer(0f);

        player1Finish = false;
        player2Finish = false;

        //GameManager.controller = this;

        //musicMan = GameObject.Find("/Controllers /Music").GetComponent<AudioSource>();

        if (GameManager.twoPlayers == false)
        {
            Debug.Log("YES!!");
            Debug.Log("One Player");
            Destroy(player2);
            Destroy(player2Cam);
            Destroy(player2VCam);
            float margin = (0.0f);
            cam1.rect = new Rect(margin, 0.0f, 1.0f - margin * 2.0f, 1.0f);
        }
        if (GameManager.twoPlayers == true)
        {
            Debug.Log("TWO!!");
        }
        GameManager.instance.LoadTimes();
        Debug.Log("On Enable...");
        pause1.ESCOn();
        Debug.Log("Starting...");
        GetComponent<GameManager>();
        musicMan.Play();
        /*musicMan = GameObject.Find("/Controllers /Music").GetComponent<AudioSource>();

        if (GameManager.twoPlayers == false)
        {
            gameManager.OnePlayer();
            Debug.Log("YES!!");
        }
        if (GameManager.twoPlayers == true)
        {
            Debug.Log("TWO!!");
        }
        GameManager.instance.LoadTimes();
        Debug.Log("On Enable...");
        pause1.ESCOn();
        Debug.Log("Starting...");
        GetComponent<GameManager>();
        musicMan.Play();*/

        if (!PhotonNetwork.IsMasterClient)
        {
            
        }
        else
        {

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
    public void StopMusic()
    {
        musicMan.Stop();
    }
    public void ResetSaveData()
    {
        GameManager.instance.ResetData();
    }
}

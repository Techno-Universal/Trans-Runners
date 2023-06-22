using System;
using System.Collections;
using System.Collections.Generic;   
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject[] players;
    public GameObject[] playerPrefabs;
    public Transform[] playerSpawns;

    public static GameManager instance;
    public GameData saveData;

    public static Timer timer;

    public static bool twoPlayers;

    public static GameController controller;

    public static SaveSystem saveSystem;

    public static float p1RecordTime;
    public static float p2RecordTime;

    public float altp1RecordTime;
    public float altp2RecordTime;

  //  public GameData data;

    public static MainMenuRecordTimes mainMenuRecordTimes;

    //public PlayerData playerData;
    public List<PlayerData> playerTimes = new List<PlayerData>();

    public List<PlayerData> currentPlayers = new List<PlayerData>();
    public Rect rect;
    // Start is called before the first frame update
    void Start()
    {
        MainMenuRecordTimes.data = this;
        #region Singleton
        if (instance != null)
        {
            Debug.Log("Removed Controller...");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        #endregion

        saveData = SaveSystem.instance.LoadGame();

        if (saveData == null) saveData = new GameData();

        LoadTimes();
        FillTempList();

        currentPlayers = new List<PlayerData>(0);
        currentPlayers.Add(new PlayerData());
        currentPlayers.Add(new PlayerData());

        //saveSystem.LoadGame();
        //data.LoadTimes();
        //timer.StartTimer();
    }
    private void OnEnable()
    {
        Debug.Log("Manager Run");

        FinishZone.manager = this;
        
        MainMenuRecordTimes.data = this;

        ResetSaveData.manager = this;

        mainMenuRecordTimes.p1Number = altp1RecordTime;
        mainMenuRecordTimes.p2Number = altp2RecordTime;

        if (instance != null)
        {
            Debug.Log("Removed Controller...");
            Destroy(gameObject);
        }
    }

    public void TwoPlayers(bool value1)
    {
        if (value1 == true)
        {
            Debug.Log("ON");
            GameManager.twoPlayers = true;
        }
        else
        {
            Debug.Log("OFF");
            GameManager.twoPlayers = false;
        }
        
    }
    public void ResetData()
    {
        Debug.Log("Data Reset!!");
        SaveSystem.instance.RemoveData();
        saveData = new GameData();
        p1RecordTime = 0;
        p2RecordTime = 0;
        mainMenuRecordTimes.SetMainMenuTimes();
    }

    public void FillTempList()
    {
        saveData.level = 1;

        //saveData.player1BestTimeL1 = p1RecordTime;
        //saveData.player2BestTimeL1 = p2RecordTime;
    }
    public void FillSaveData()
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerData data = new PlayerData();
        }
    }
    public void SortFunc()
    {

    }
    public void AutoSave1()
    {
        Debug.Log("Saving...");
        if (controller.player1FinishTimeNumber <= p1RecordTime || p1RecordTime <= 0)
        {
            Debug.Log("New Record P1!");
            p1RecordTime = controller.player1FinishTimeNumber;
            controller.nR1.gameObject.SetActive(true);
            FillTempList();
            FillSaveData();
            SetTimes();
            SaveSystem.instance.SaveGame(saveData);
        }
    }
    public void AutoSave2()
    {
        if (controller.player2FinishTimeNumber <= p2RecordTime || p2RecordTime <= 0)
        {
            Debug.Log("New Record P2!");
            p2RecordTime = controller.player2FinishTimeNumber;
            controller.nR2.gameObject.SetActive(true);
            FillTempList();
            FillSaveData();
            SetTimes();
            SaveSystem.instance.SaveGame(saveData);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    // public void ResetData()
    //{
    //  Debug.Log("Save Data Reset!");
    //player1BestTimeL1 = 0;
    // player2BestTimeL1 = 0;
    //level = 0;
    //}
    public void SetTimes()
    {
        Debug.Log("Times Set...");
        saveData.player1BestTimeL1 = p1RecordTime;
        saveData.player2BestTimeL1 = p2RecordTime;
        //data.player2BestTimeL1 = 0;
        altp1RecordTime = p1RecordTime;
        altp2RecordTime = p2RecordTime;
    }
    public void LoadTimes()
    {
       // PlayerData data = new PlayerData();
       // Debug.Log("Times loaded...");
        altp1RecordTime = saveData.player1BestTimeL1;
        altp2RecordTime = saveData.player2BestTimeL1;
        p1RecordTime = saveData.player1BestTimeL1;
        p2RecordTime = saveData.player2BestTimeL1;
        mainMenuRecordTimes.p1Number = altp1RecordTime;
        mainMenuRecordTimes.p2Number = altp2RecordTime;
    }
    public void SetMainMenuTimeNumbers()
    {
        mainMenuRecordTimes.p1Number = altp1RecordTime;
        mainMenuRecordTimes.p2Number = altp2RecordTime;
    }
    void SpanwPlayerAtStart()
    {
        //SpawnPlayer
        int a = PhotonNetwork.LocalPlayer.ActorNumber - 1;
        GameObject player = PhotonNetwork.Instantiate(playerPrefabs[a].name, playerSpawns[a].position, Quaternion.identity).gameObject;
        if (player == null) Debug.Log("No player reference");
        Invoke("CallAddPlayerToList", 1);

        //assign camera in scene
        // player.GetComponentInChildren<Camera>().tag = "MainCamera";
    }
}


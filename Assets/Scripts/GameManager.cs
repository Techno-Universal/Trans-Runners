using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameData saveData;

    public Timer timer;

    public GameObject player2;
    public GameObject player2Cam;
    public GameObject player2VCam;

    public GameController controller;

    public SaveSystem saveSystem;

    public static float p1RecordTime;
    public static float p2RecordTime;

    public Camera cam1;

    public float altp1RecordTime;
    public float altp2RecordTime;

    public GameObject nR1;
    public GameObject nR2;

    public GameData data;

    //public PlayerData playerData;
    public List<PlayerData> playerTimes = new List<PlayerData>();

    public List<PlayerData> currentPlayers = new List<PlayerData>();
    public Rect rect;
    // Start is called before the first frame update
    void Start()
    {
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

        cam1 = GetComponent<Camera>();

        //saveSystem.LoadGame();
        //data.LoadTimes();
        //timer.StartTimer();
    }
    private void Awake()
    {
        AssignObjects();
    }
    public void ResetData()
    {
        //GameData.level = 0;
    }

    public void FillTempList()
    {
        saveData.level = 1;

        saveData.player1BestTimeL1 = p1RecordTime;
        saveData.player2BestTimeL1 = p2RecordTime;
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
    public void AutoSave()
    {
        Debug.Log("Saving...");
        if (controller.player1FinishTimeNumber <= p1RecordTime || p1RecordTime <= 0)
        {
            Debug.Log("New Record P1!");
            p1RecordTime = controller.player1FinishTimeNumber;
            nR1.gameObject.SetActive(true);
            FillTempList();
            FillSaveData();
            SetTimes();
            SaveSystem.instance.SaveGame(saveData);
        }
        if (controller.player2FinishTimeNumber <= p1RecordTime)
        {
            Debug.Log("New Record P2!");
            p2RecordTime = controller.player2FinishTimeNumber;
            nR2.gameObject.SetActive(true);
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
    public void OnePlayer()
    {
        Debug.Log("One Player");
        Destroy(player2);
        Destroy(player2Cam);
        Destroy(player2VCam);
        float margin = (0.0f);
        cam1.rect = new Rect(margin, 0.0f, 1.0f - margin * 2.0f, 1.0f);
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
        data.player1BestTimeL1 = p1RecordTime;
        data.player2BestTimeL1 = p2RecordTime;
        //data.player2BestTimeL1 = 0;
        altp1RecordTime = p1RecordTime;
        altp2RecordTime = p2RecordTime;
    }
    public void LoadTimes()
    {
        PlayerData data = new PlayerData();
        Debug.Log("Times loaded...");
        altp1RecordTime = data.player1BestTimeL1;
        altp2RecordTime = data.player2BestTimeL1;
    }
    public void AssignObjects()
    {
        /*if (player2 != null)
        {
            Debug.Log("Objects Found!!!");
        }
        else
        {
            Debug.Log("Loading objects...");

            timer = GameObject.Find("/Timer").GetComponent<Timer>();
            player2 = GameObject.Find("/Player2");
            player2Cam = GameObject.Find("/Player2 Camera");
            player2VCam = GameObject.Find("/P2 Vcam");
            nR1 = GameObject.Find("/UI canvas /Level Complete Screeen /NR1");
            nR2 = GameObject.Find("/UI canvas /Level Complete Screeen /NR2");
            cam1 = GameObject.Find("/Player1 Camera").GetComponent<Camera>();

            Debug.Log(player2.gameObject.name);

            AssignObjects();
        }*/
           
    }
}


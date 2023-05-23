using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public PlayerData playerData;

    public Rect rect;
    // Start is called before the first frame update
    void Start()
    {
       /*#region Singleton
       if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        #endregion */

        saveData = SaveSystem.instance.LoadGame();

        //if (saveData == null) saveData = new List<PlayerData>(0);

        FillTempList();

        saveData.currentPlayers = new List <PlayerData>(0);
        saveData.currentPlayers.Add(new PlayerData());
        saveData.currentPlayers.Add(new PlayerData());

        cam1 = GetComponent<Camera>();

        //saveSystem.LoadGame();
        //data.LoadTimes();
        //timer.StartTimer();
    }
    private void Awake()
    {

        saveSystem.LoadGame();
        data.LoadTimes();
    }
    public void ResetData()
    {
        //GameData.level = 0;
    }

    public void FillTempList()
    {
        playerData.level = 1;

        playerData.player1BestTimeL1 = p1RecordTime;
        playerData.player2BestTimeL1 = p2RecordTime;
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
        if (controller.player1FinishTimeNumber >= p1RecordTime)
        {
            p1RecordTime = controller.player1FinishTimeNumber;
            nR1.gameObject.SetActive(true);
            FillTempList();
            FillSaveData();
            saveData.SetTimes();
            SaveSystem.instance.SaveGame(saveData);
        }
        if (controller.player2FinishTimeNumber >= p1RecordTime)
        {
            p2RecordTime = controller.player2FinishTimeNumber;
            nR2.gameObject.SetActive(true);
            FillTempList();
            FillSaveData();
            saveData.SetTimes();
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
}

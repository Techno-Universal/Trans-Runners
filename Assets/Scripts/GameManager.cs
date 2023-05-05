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

    public Camera cam1;

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

        //timer.StartTimer();
    }
    public void ResetData()
    {
        //GameData.level = 0;
    }

    public void FillTempList()
    {
        PlayerData data = new PlayerData();


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
        FillTempList();
        FillSaveData();
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

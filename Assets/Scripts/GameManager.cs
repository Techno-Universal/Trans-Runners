using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameData saveData;

    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        #region Singleton
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        #endregion

        saveData = SaveSystem.instance.LoadGame();

        //if (saveData == null) saveData = new List<PlayerData>(0);

        FillTempList();

        saveData.currentPlayers = new List <PlayerData>(0);
        saveData.currentPlayers.Add(new PlayerData());
        saveData.currentPlayers.Add(new PlayerData());

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
    }
}

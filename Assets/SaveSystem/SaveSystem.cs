using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    static public SaveSystem instance;
    string filePath;
    public string fileName = "save1";

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
        filePath = Application.persistentDataPath + "/" + fileName + ".data";

    }
    public void SaveGame(GameData saveData)
    {
        FileStream dataStream = new FileStream(filePath, FileMode.Create);

        BinaryFormatter converter = new BinaryFormatter();
        converter.Serialize(dataStream, saveData);

        dataStream.Close();
    }
    public GameData LoadGame()
    {
        if (File.Exists(filePath))
        {
            Debug.Log("Loading Save File...");
            FileStream dataStream = new FileStream(filePath, FileMode.Open);

            BinaryFormatter converter = new BinaryFormatter();

            GameData saveData = converter.Deserialize(dataStream) as GameData;

            dataStream.Close();
            return saveData;
        }
        else
        {
            Debug.LogWarning("No Save Files Found In:" + filePath);
            return null;
        }
    }
    public void RemoveData()
    {
        Debug.Log("Data removed!!");
        File.Delete(Path.Combine(Application.persistentDataPath, "/save1.data"));
        filePath = Application.persistentDataPath + "/" + fileName + ".data";
    }
}

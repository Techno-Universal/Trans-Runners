using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnlineLobby : MonoBehaviourPunCallbacks
{
    public bool[] playersReady;

    public PhotonView view;

    public TMP_Text roomName;
    public TMP_Text messages;
    public TMP_Text numberOfPlayers;
    public TMP_InputField playerName;

    public string levelName;

    void Start()
    {
        playersReady = new bool[playersReady.Length];
    }

    public void LoadLevel()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            SceneManager.LoadScene("Level1");
        }
        else
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

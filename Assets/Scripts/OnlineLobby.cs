using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using Photon.Realtime;
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

    public GameObject loadingText;

    void Start()
    {
        //PhotonNetwork.ConnectUsingSettings();
        playersReady = new bool[PhotonNetwork.CurrentRoom.MaxPlayers];
        PhotonNetwork.LocalPlayer.NickName = "Player " + PhotonNetwork.LocalPlayer.ActorNumber;
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;

        numberOfPlayers.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + " / " + PhotonNetwork.CurrentRoom.MaxPlayers;
    }

    public void UpdateName()
    {
        PhotonNetwork.LocalPlayer.NickName = playerName.text;
    }

    public void LoadLevel()
    {
        if(!PhotonNetwork.IsMasterClient)
        {
            messages.text = "Illigal action: You are not the host.";
        }
        else if (PhotonNetwork.CurrentRoom.PlayerCount < PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            messages.text = "Waiting for players... Lobby still has availability.";
        }
        else
        {
            SceneManager.LoadScene("Level1");
        }
        
    }

    [PunRPC]
    public void ReadyPLayer(int playerNumber, bool isReady)
    {
        playersReady[playerNumber] = isReady;
    }

    public void RunReadyPLayer(bool isReady)
    {
        view.RPC("ReadyPlayer", RpcTarget.All, PhotonNetwork.LocalPlayer.ActorNumber, isReady);
    }
    bool AllPlayersReady()
    {
        foreach(bool item in playersReady)
        {
            if (item == false) return false;
        }
        return true;
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        numberOfPlayers.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + " / " + PhotonNetwork.CurrentRoom.MaxPlayers;
        Invoke("UpdateBoolsOnJoin", 1);
        if (!PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("Level1Online");
            loadingText.gameObject.SetActive(true);
        }
        else
        {
            OnJoinedLobby();
        }
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerEnteredRoom(otherPlayer);
        numberOfPlayers.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + " / " + PhotonNetwork.CurrentRoom.MaxPlayers;
        view.RPC("ReadyPlayer", RpcTarget.All, otherPlayer.ActorNumber, false);
    }
    void UpdateBoolOnJoin()
    {
        int playerNUmber = PhotonNetwork.LocalPlayer.ActorNumber;
        bool isReady = playersReady[ playerNUmber - 1];

        view.RPC("ReadyPlayer", RpcTarget.All, playerNUmber, isReady);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnJoinedLobby()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Wait for Player2...");
        }
        else
        {
            PhotonNetwork.LoadLevel("Level1Online");
            loadingText.gameObject.SetActive(true);
        }
    }
}

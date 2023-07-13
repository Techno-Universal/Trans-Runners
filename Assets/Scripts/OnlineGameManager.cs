using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class OnlineGameManager : MonoBehaviourPunCallbacks
{

    public int maxPlayerCount = 2;

    public bool isFull;

    #region Photon Callbacks

    public override void OnPlayerEnteredRoom(Player other)
    {
        Debug.LogFormat("OnPlayerEnteredRoom() {0} ", other.NickName);

        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerEnteredRoom() IsMasterClient() {0}", PhotonNetwork.IsMasterClient);

            if (PhotonNetwork.CountOfPlayers == maxPlayerCount) 
            {
                isFull = true;
                SceneManager.LoadScene("Level1Online");
            }
            else if (PhotonNetwork.CountOfPlayers < maxPlayerCount)
            {
                isFull = false;
            }
        }
    }

    public override void OnPlayerLeftRoom(Player other)
    {
        Debug.LogFormat("OnPlayerLeftRoom() {0} ", other.NickName);

        SceneManager.LoadScene("Lobby");
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerLeftRoom() IsMasterClient() {0}", PhotonNetwork.IsMasterClient);

            if (PhotonNetwork.CountOfPlayers == maxPlayerCount)
            {
                isFull = true;
                SceneManager.LoadScene("Level1Online");
            }
            else if (PhotonNetwork.CountOfPlayers < maxPlayerCount)
            {
                isFull = false;
            }
        }
    }
    #endregion

    void LoadLevel()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("Unable to Load Level1. You are not the Master Client...");
        }
        Debug.Log("Loading Level1...");
        if (isFull)
        {
            PhotonNetwork.LoadLevel("Room for" + PhotonNetwork.CurrentRoom.PlayerCount);
        }
        else
        {
            Debug.Log("Player2 Not connected...");
        }
    }

}

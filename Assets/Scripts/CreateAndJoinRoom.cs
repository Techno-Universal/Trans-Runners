using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;

    public OnlineLobby lobby;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
        //lobby.LoadLevel();
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
        Debug.Log("Join room...");
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Entering room...");
        //lobby.LoadLevel();
        //Uncomment line 27 to test online level.

        //PhotonNetwork.LoadLevel("Level1Online");
        if (!PhotonNetwork.IsMasterClient)
        {
            lobby.LoadLevel();
        }
    }
    public void OnPlayerEnteredRoom(PlayerNumber newPlayer)
    {
        Debug.Log("Entered room...");
        //PhotonNetwork.LoadLevel("Level1Online");
        lobby.LoadLevel();

        /*if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("Level1Online");
            lobby.LoadLevel();
        }*/
    }
}

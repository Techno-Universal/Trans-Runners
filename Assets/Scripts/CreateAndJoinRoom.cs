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

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        //Uncomment line 27 to test online level.

        //PhotonNetwork.LoadLevel("Level1Online");
        if (!PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("Level1Online");
        }
    }
}

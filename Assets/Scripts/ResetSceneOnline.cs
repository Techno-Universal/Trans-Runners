using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ResetSceneOnline : MonoBehaviourPunCallbacks
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ResetSceneOnline!");
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class LoadNextScene : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update

    public GameObject playerExit;

    public GameObject hostExit;

    public GameObject offlineWarning;

    public PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }
    public void LoadLevel1()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level1");
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1.0f;
        //PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel("MainMenu");
        //SceneManager.LoadScene("MainMenu");
    }
    public void LoadOnlineLobby()
    {
        if (PhotonNetwork.IsConnected)
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Lobby");
        }
        else
        {
            offlineWarning.gameObject.SetActive(true);
        }
    }
    public void ExitRoom()
    {
        view.RPC("ExitRoom2", RpcTarget.All);
        PhotonNetwork.LeaveRoom();
    }
    [PunRPC]
    public void ExitRoom2()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            playerExit.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            hostExit.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
    public void OnApplicationQuit()
    {
        ExitRoom();
    }
}

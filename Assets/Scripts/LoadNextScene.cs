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
    
    public void LoadLevel1()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level1");
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadOnlineLobby()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Lobby");
    }
    public void ExitRoom()
    {
        PhotonNetwork.LeaveRoom();
        ExitRoom2();
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
}

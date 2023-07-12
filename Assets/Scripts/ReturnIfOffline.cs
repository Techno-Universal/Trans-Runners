using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class ReturnIfOffline : MonoBehaviourPunCallbacks
{

    public GameObject offlineWarning;

    public bool offlineBool;

    void Update()
    {
        if (offlineBool == false)
        {
            if (PhotonNetwork.IsConnected)
            {
                Debug.Log("Online...");
            }
            else
            {
                offlineWarning.gameObject.SetActive(true);
                offlineBool = true;
                Debug.Log("Offline...");
            }
        }
    }
    public void OnConnectionFail(DisconnectCause cause)
    {
        offlineWarning.gameObject.SetActive(true);
        offlineBool = true;
        Debug.Log("Offline...");
    }
    public void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        offlineWarning.gameObject.SetActive(true);
        offlineBool = true;
        Debug.Log("Offline...");
    }
}

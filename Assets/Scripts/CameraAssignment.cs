using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;

public class CameraAssignment : MonoBehaviour
{
    CinemachineVirtualCamera vcam;

    // Start is called before the first frame update
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        Invoke("AssignCameraTarget", 3);
    }

    void AssignCameraTarget()
    {
        int num = PhotonNetwork.LocalPlayer.ActorNumber -1;
        vcam.Follow = GameManager.instance.players[num].transform;
        vcam.LookAt = GameManager.instance.players[num].transform;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;

public class CameraAssignment2 : MonoBehaviour
{
    public CinemachineVirtualCamera vcam1;

    public Transform player1;

    // Start is called before the first frame update
    void Start()
    {
        vcam1 = GetComponent<CinemachineVirtualCamera>();

        Invoke("AssignCameraTarget", 1);
        //AssignCameraTarget();
    }

    void AssignCameraTarget()
    {
        Debug.Log("AssignCam1");
        vcam1.Follow = player1.transform;
        vcam1.LookAt = player1.transform;
    }
}

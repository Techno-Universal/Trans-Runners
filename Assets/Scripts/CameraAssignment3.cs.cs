using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;

public class CameraAssignment3 : MonoBehaviour
{
    public CinemachineVirtualCamera vcam2;

    public Transform player2;

    // Start is called before the first frame update
    void Start()
    {
        vcam2 = GetComponent<CinemachineVirtualCamera>();
        Invoke("AssignCameraTarget", 1);
        //AssignCameraTarget();
    }

    void AssignCameraTarget()
    {
        Debug.Log("AssignCam2");
        vcam2.Follow = player2.transform;
        vcam2.LookAt = player2.transform;
    }
}

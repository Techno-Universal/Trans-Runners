using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOnSceneClose : MonoBehaviour
{
    
    public GameObject controller;

    public void DestroyController()
    {
        Destroy(controller);
    }
}

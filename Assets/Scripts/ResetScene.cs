using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{

    public DestroyObjectOnSceneClose delete;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ResetScene!");
        delete.DestroyController();
        SceneManager.LoadScene("Level1");
    }
}

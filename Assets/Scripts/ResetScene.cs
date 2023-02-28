using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ResetScene!");
        SceneManager.LoadScene("Level1");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    // Start is called before the first frame update
    
    
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
}

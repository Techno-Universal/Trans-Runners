using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenOpener : MonoBehaviour
{
    private bool escOn = true;

    public GameObject PauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (escOn == true && Input.GetKeyDown(KeyCode.Escape) == true)
        {
            DoAction();
        }
    }
    public void ContinueGame()
    {
        Time.timeScale = 1.0f;
    }
    public void DoAction()
    {
        PauseScreen.gameObject.SetActive(!PauseScreen.gameObject.activeSelf);
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }    
    }
    public void ESCOff()
    {
        Debug.Log("ESC Off");
        escOn = false;
    }
    public void ESCOn()
    {
        Debug.Log("ESC On");
        escOn = true;
    }
}

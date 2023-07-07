using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnlinePauseScreenOpener : MonoBehaviour
{
    public bool escOn = true;

    public GameObject PauseScreen;

    public OnlineTimer timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("EscTest");
        if (escOn == true && Input.GetKeyDown(KeyCode.Escape) == true)
        {
            DoAction();
        }
    }
    public void ContinueGame()
    {
        Time.timeScale = 1.0f;
        PauseScreen.gameObject.SetActive(false);
        timer.isTiming = true;
    }
    public void DoAction()
    {
        Debug.Log("EscDown");
        //PauseScreen.gameObject.SetActive(!PauseScreen.gameObject.activeSelf);
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.0f;
            PauseScreen.gameObject.SetActive(true);
            timer.isTiming = false;
        }
        else if (Time.timeScale == 0.0f)
        {
            Time.timeScale = 1.0f;
            PauseScreen.gameObject.SetActive(false);
            timer.isTiming = true;
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
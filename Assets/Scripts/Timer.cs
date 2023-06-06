using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float startTime = 0;
    public float currentTime;

    public string displayTime;
    public bool isTiming = false;

    public UnityEvent TimesUp;

    public static InLevelUI timeUI;

    // Update is called once per frame
    private void Start()
    {
        InLevelUI.timer = this;
        displayTime = "00:00";
    }
    private void OnEnable()
    {
        //isTiming = false;
        //currentTime = 0;
        //StartTimer(startTime);
        //timeUI = GameObject.Find("InLevelUI").GetComponent<InLevelUI>();
        //isTiming = true;
    }

    void Update()
    {
        if (isTiming == true)
        {
            Debug.Log("TimerRun");
            currentTime += Time.deltaTime;

            //format the time
            string minutes = Mathf.Floor(currentTime / 60).ToString("00");
            string seconds = (currentTime % 60).ToString("00");

            if(currentTime <= 0)
            {
                displayTime = "00:00";
                isTiming = false;
                TimesUp.Invoke();
            }
            else
            {
                displayTime = string.Format("{0}:{1}", minutes, seconds);
            }
        }
        timeUI.UpdateUI();
    }
    public void StartTimer(float length)
    {
        startTime = length;
        currentTime = startTime;
        isTiming = true;
    }
    public void StopTimer()
    {
        isTiming = false;
        timeUI.DisableTimer();
    }

}

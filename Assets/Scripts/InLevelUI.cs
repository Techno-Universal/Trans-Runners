using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InLevelUI : MonoBehaviour
{
    public TMP_Text mainTimer;

    public TMP_Text p1FinTime;

    public TMP_Text p2FinTime;

    public CanvasGroup resultGroup;

    public float fadeRate;

    public static Timer timer;

    public bool levelComplete = false;

    public GameObject levelCompleteUI;

    public GameController controller;

    public GameObject newRecordSign1;
    public GameObject newRecordSign2;

    public void UpdateUI()
    {
        if (levelComplete == false)
        {
            mainTimer.text = timer.displayTime;
        }
    }   
    // Start is called before the first frame update
    void Start()
    {
       Timer.timeUI = this;
    }

    public void AllPlayersFInished()
    {
        Debug.Log("AllPLayersFinish");
        StartCoroutine(DisplayCanvas(fadeRate));
        p1FinTime.text = controller.player1FinishTime;
        p2FinTime.text = controller.player2FinishTime;
        levelCompleteUI.SetActive(true);
        timer.StopTimer();

    }
    IEnumerator DisplayCanvas(float rate)
    {
        if (LevelManager.instance.currentState == LevelManager.GameStates.Finish)
        {

        }

        while (resultGroup.alpha < 0.9f)
        {
            resultGroup.alpha = Mathf.Lerp(resultGroup.alpha, 1, rate);
            yield return new WaitForEndOfFrame();
        }

        resultGroup.alpha = 1f;
        yield return null;
    }
    public void DisableTimer()
    {
        mainTimer.gameObject.SetActive(false);
    }
}

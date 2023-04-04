using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InLevelUI : MonoBehaviour
{
    public TMP_Text mainTimer;

    public CanvasGroup resultGroup;

    public float fadeRate;

    public Timer timer;

    public void UpdateUI()
    {
        if (LevelManager.instance.currentState == LevelManager.GameStates.Running)
        {
            mainTimer.text = timer.displayTime;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AllPlayersFInished()
    {
        StartCoroutine(DisplayCanvas(fadeRate));
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
    
}

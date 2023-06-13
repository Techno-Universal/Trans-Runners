using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuRecordTimes : MonoBehaviour
{
    public float p1Number;

    public float p2Number;

    public string p11RTT;

    public string p22RTT;

    public TMP_Text p11RTTText;

    public TMP_Text p22RTTText;

    public static GameManager data;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
       GameManager.mainMenuRecordTimes = this;
       SetMainMenuTimes();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMainMenuTimes()
    {
        GameManager.mainMenuRecordTimes = this;

        p1Number = GameManager.p1RecordTime;
        p2Number = GameManager.p2RecordTime;

        Debug.Log("Set record times in main menu...");
        string minutes1 = Mathf.Floor(p1Number / 60).ToString("00");
        string seconds1 = (p1Number % 60).ToString("00");

        p11RTT = string.Format("{0}:{1}", minutes1, seconds1);

        string minutes2 = Mathf.Floor(p2Number / 60).ToString("00");
        string seconds2 = (p2Number % 60).ToString("00");

        p22RTT = string.Format("{0}:{1}", minutes2, seconds2);

        p11RTTText.text = p11RTT;

        p22RTTText.text = p22RTT;

        //p11RTTText = GameObject.Find("BestTime1").GetComponent<TMP_Text>();

        //p22RTTText = GameObject.Find("BestTime2").GetComponent<TMP_Text>();


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{

    public CanvasGroup resultGroup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            bool player1Finish = true;
        }
        if (other.tag == "Player2")
        {
            bool player2Finish = true;
        }
    }
    

}

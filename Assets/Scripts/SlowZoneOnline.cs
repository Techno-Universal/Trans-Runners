using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZoneOnline : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;

    public GameObject player2;

    public OnlineCharacterMovement oCM1;

    public OnlineCharacterMovement oCM2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            player1.GetComponent<OnlineCharacterMovement>().SlowOnline();
            oCM1.SlowOnline();
        }
        if (other.tag == "Player2")
        {
            player2.GetComponent<OnlineCharacterMovement>().SlowOnline();
            oCM2.SlowOnline();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player1")
        {
            player1.GetComponent<OnlineCharacterMovement>().ReturnSpeedOnline();
            oCM1.SlowOnline();
        }
        if (other.tag == "Player2")
        {
            player2.GetComponent<OnlineCharacterMovement>().ReturnSpeedOnline();
            oCM2.SlowOnline();
        }
    }
}

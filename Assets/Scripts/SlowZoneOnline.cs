using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZoneOnline : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;

    public GameObject player2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            player1.GetComponent<OnlineCharacterMovement>().SlowOnline();
        }
        if (other.tag == "Player2")
        {
            player2.GetComponent<OnlineCharacterMovement>().SlowOnline();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player1")
        {
            player1.GetComponent<OnlineCharacterMovement>().ReturnSpeedOnline();
        }
        if (other.tag == "Player2")
        {
            player2.GetComponent<OnlineCharacterMovement>().ReturnSpeedOnline();
        }
    }
}

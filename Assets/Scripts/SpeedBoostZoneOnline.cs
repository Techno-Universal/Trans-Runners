using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostZoneOnline : MonoBehaviour
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
            Debug.Log("Speed1");
            //player1.GetComponent<OnlineCharacterMovement>().SpeedBoostOnline();
            oCM1.SpeedBoostOnline();
        }
        else if (other.tag == "Player2")
        {
            Debug.Log("Speed2");
            //player2.GetComponent<OnlineCharacterMovement>().SpeedBoostOnline();
            oCM2.SpeedBoostOnline();
        }
    }
   
}

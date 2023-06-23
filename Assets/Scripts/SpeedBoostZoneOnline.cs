using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostZoneOnline : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player1;

    public GameObject player2;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            player1.GetComponent<OnlineCharacterMovement>().SpeedBoostOnline();
        }
        if (other.tag == "Player2")
        {
            player2.GetComponent<OnlineCharacterMovement>().SpeedBoostOnline();
        }
    }
   
}

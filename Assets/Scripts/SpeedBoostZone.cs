using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostZone : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
           
        }
        if (other.tag == "Player2")
        {
           
        }
    }
   
}

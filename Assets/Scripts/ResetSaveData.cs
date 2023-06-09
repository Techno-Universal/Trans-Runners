using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSaveData : MonoBehaviour
{
   public static GameManager manager;

   public void ResetDataButton()
    {
        manager.ResetData();
    }
}

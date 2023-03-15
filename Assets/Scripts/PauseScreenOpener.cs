using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenOpener : MonoBehaviour
{

    public GameObject PauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen.gameObject.SetActive(!PauseScreen.gameObject.activeSelf);
        }
    }
}

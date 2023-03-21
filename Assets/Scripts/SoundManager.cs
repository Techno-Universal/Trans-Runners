using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public void SetVolume(float sliderValue)
    {
      audioMixer.SetFloat("Volume", Mathf.Log10(sliderValue) * 20);
      
    }
    // Start is called before the first frame update
   
}

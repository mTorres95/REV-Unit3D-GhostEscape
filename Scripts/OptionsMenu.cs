using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
 
    // Modify the volumen of the music using the slider of the Options Menu 
    // (using MusicMixer)
    public void SetVolume ( float sliderValue ) {
        // Convert sliderValue to log so it works better with the AudioMixer
        audioMixer.SetFloat("volume", Mathf.Log10(sliderValue)*20 );
    }
    
}

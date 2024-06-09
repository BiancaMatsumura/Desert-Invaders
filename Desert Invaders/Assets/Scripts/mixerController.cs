using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class mixerController : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider soundsVol;
    public Slider musicVol;




    void Start()
    {
        
    }

    public void MusicVolChange()
    {
        mixer.SetFloat("musicVol", musicVol.value);
    }

    public void SoundVolChange()
    {
        mixer.SetFloat("soundsVol", soundsVol.value);
    }

    public void StopMusic()
    {
        mixer.SetFloat("musicVol", -80);
    }

    public void StopSounds()
    {
        mixer.SetFloat("soundsVol", -80);
    }

    public void PlayMusic()
    {
        mixer.SetFloat("musicVol", 0);
    }

    public void PlaySounds()
    {
        mixer.SetFloat("soundsVol", 0);
    }
}



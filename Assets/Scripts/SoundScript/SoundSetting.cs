using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSetting : MonoBehaviour
{
    
    private static readonly string BackgroundPrefs = "BackgroundPrefs";
    private static readonly string SoundEffectPrefs = "SoundEffectPrefs";
    private float backgroundFloat, soundeffectFloat;
    
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;
    
    private void Awake()
    {
        ContinueSetting();
    }

    private void ContinueSetting()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPrefs);
        soundeffectFloat = PlayerPrefs.GetFloat(SoundEffectPrefs);

        backgroundAudio.volume = backgroundFloat;

        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundeffectFloat;
        }
    }
}

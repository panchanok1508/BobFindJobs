using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPrefs = "BackgroundPrefs";
    private static readonly string SoundEffectPrefs = "SoundEffectPrefs";
    private int firstplayInt;
    public Slider backgroundSlider, soundEffectSlider;
    private float backgroundFloat, soundeffectFloat;

    public AudioSource settingBackgroundAudio;
    public AudioSource menuBackgroundAudio;
    public AudioSource selectBackgroundAudio;
    public AudioSource spyBackgroundAudio;
    public AudioSource thiefBackgroundAudio;
    public AudioSource hackerBackgroundAudio;
    public AudioSource[] soundEffectsAudio;

    void Start()
    {
        firstplayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstplayInt == 0)
        {
            backgroundFloat = .25f;
            soundeffectFloat = .75f;
            backgroundSlider.value = backgroundFloat;
            soundEffectSlider.value = soundeffectFloat;
            PlayerPrefs.SetFloat(BackgroundPrefs,backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectPrefs,soundeffectFloat);
            PlayerPrefs.SetInt(FirstPlay,-1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPrefs);
            backgroundSlider.value = backgroundFloat;
            soundeffectFloat = PlayerPrefs.GetFloat(SoundEffectPrefs);
            soundEffectSlider.value = soundeffectFloat;

        }
    }

    public void SaveSoundSetting()
    {
        PlayerPrefs.SetFloat(BackgroundPrefs,backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectPrefs, soundEffectSlider.value);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSetting();
        }
    }

    public void UpdateSound()
    {
        settingBackgroundAudio.volume = backgroundSlider.value;
        menuBackgroundAudio.volume = backgroundSlider.value;
        selectBackgroundAudio.volume = backgroundSlider.value;
        spyBackgroundAudio.volume = backgroundSlider.value;
        thiefBackgroundAudio.volume = backgroundSlider.value;
        hackerBackgroundAudio.volume = backgroundSlider.value;

        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectSlider.value;
        }
    }
}

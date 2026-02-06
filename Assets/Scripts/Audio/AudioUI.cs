using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioUI : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVol", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVol", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVol", 1f);

        AudioManager.instance?.SetMusicVolume(masterSlider.value);
        AudioManager.instance?.SetMusicVolume(musicSlider.value);
        AudioManager.instance?.SetSFXVolume(sfxSlider.value);

        masterSlider.onValueChanged.AddListener(v => {
            AudioManager.instance?.SetMasterVolume(v);
            PlayerPrefs.SetFloat("MasterVol", v);
        });
        musicSlider.onValueChanged.AddListener(v => {
            AudioManager.instance?.SetMusicVolume(v);
            PlayerPrefs.SetFloat("MusicVol", v);
        });
        sfxSlider.onValueChanged.AddListener(v => {
            AudioManager.instance?.SetSFXVolume(v);
            PlayerPrefs.SetFloat("SFXVol", v);
        });
    }
}

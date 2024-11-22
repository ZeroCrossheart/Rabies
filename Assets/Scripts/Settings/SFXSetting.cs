using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSetting : MonoBehaviour
{
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private AudioSource SFX;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SFXVolume"))
            LoadSFXVolume();
        else
        {
            PlayerPrefs.SetFloat("SFXVolume", 1);
            LoadSFXVolume();
        }
    }

    public void SetSFXVolume()
    {
        SFX.volume = SFXSlider.value;
        SaveSFXVolume();
    }

    public void SaveSFXVolume()
    {
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    }

    public void LoadSFXVolume()
    {
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
}

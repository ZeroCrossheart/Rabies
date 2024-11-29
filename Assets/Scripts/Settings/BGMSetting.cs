using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMSetting : MonoBehaviour
{
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private AudioSource BGM;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("BGMVolume"))
            LoadBGMVolume();
        else
        {
            PlayerPrefs.SetFloat("BGMVolume", 1);
            LoadBGMVolume();
        }
    }

    public void SetBGMVolume()
    {
        BGM.volume = BGMSlider.value;
        SaveBGMVolume();
    }

    public void SaveBGMVolume()
    {
        PlayerPrefs.SetFloat("BGMVolume", BGMSlider.value);
    }

    public void LoadBGMVolume()
    {
        BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume");
    }
}

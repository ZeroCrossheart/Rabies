using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject retry;
    [SerializeField] private GameObject settingScreen;
    [SerializeField] private GameObject tutorialOverlay;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    public void PauseScene()
    {
        /*source.clip = clip;
        source.Play();*/
        if (/*win.activeInHierarchy == false && */retry.activeInHierarchy == false && pauseScreen.activeInHierarchy == false && settingScreen.activeInHierarchy == false && tutorialOverlay.activeInHierarchy == false)
        {
            source.clip = clip;
            source.Play();
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        };
    }

    public void OpenSetting()
    {
        source.clip = clip;
        source.Play();
        settingScreen.SetActive(true);
        pauseScreen.gameObject.SetActive(false);
    }

    public void ResumeScene()
    {
        source.clip = clip;
        source.Play();
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }
}

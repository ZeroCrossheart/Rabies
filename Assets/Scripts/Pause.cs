using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject retry;
    [SerializeField] private GameObject settingScreen;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    private void Awake()
    {
        source.clip = clip;
    }

    public void PauseScene()
    {
        source.Play();
        if (/*win.activeInHierarchy == false && */retry.activeInHierarchy == false && pauseScreen.activeInHierarchy == false && settingScreen.activeInHierarchy == false)
        {
            source.Play();
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        };
    }

    public void OpenSetting()
    {
        source.Play();
        settingScreen.SetActive(true);
        pauseScreen.gameObject.SetActive(false);
    }

    public void ResumeScene()
    {
        source.Play();
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }
}

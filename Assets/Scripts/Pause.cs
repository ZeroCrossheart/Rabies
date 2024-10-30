using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject retry;

    public void PauseScene()
    {
        if (win.activeInHierarchy == false && retry.activeInHierarchy == false && pauseScreen.activeInHierarchy == false)
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        };
    }

    public void ResumeScene()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject tutorialOverlay;

    [SerializeField] private GameObject currentOverlay;
    [SerializeField] private GameObject nextOverlay;
    [SerializeField] private GameObject prevOverlay;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    public void OpenOverlay()
    {
        source.clip = clip;
        source.Play();
        tutorialOverlay.SetActive(true);
        NextOverlay();
        Time.timeScale = 0f;
    }

    public void NextOverlay()
    {
        if (currentOverlay != null)
        {
            source.clip = clip;
            source.Play();
            currentOverlay.SetActive(false);
            nextOverlay.SetActive(true);
        }
        else
        {
            source.clip = clip;
            source.Play();
            nextOverlay.SetActive(true);
        }
    }

    public void PrevOverlay()
    {
        if (currentOverlay != null)
        {
            source.clip = clip;
            source.Play();
            currentOverlay.SetActive(false);
            prevOverlay.SetActive(true);
        }
        else
        {
            source.clip = clip;
            source.Play();
            prevOverlay.SetActive(true);
        }
    }

    public void CloseOverlay()
    {
        source.clip = clip;
        source.Play();
        nextOverlay.SetActive(false);
        currentOverlay.SetActive(false);
        prevOverlay.SetActive(false);
        tutorialOverlay.SetActive(false);
        Time.timeScale = 1.0f;
    }
}

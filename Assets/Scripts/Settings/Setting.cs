using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    public void BackToMenu()
    {
        source.clip = clip;
        source.Play();
        pauseScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
}

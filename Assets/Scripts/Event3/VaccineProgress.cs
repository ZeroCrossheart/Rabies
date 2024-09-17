using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class VaccineProgress : MonoBehaviour
{
    [Header("Progress Bar")]
    public int progress = 0;
    public int maxProgress = 100;
    [SerializeField] private int addProgess = 10;

    [Header("References")]
    [SerializeField] private Image progressImage;
    [SerializeField] private GameObject win;

    private void Awake()
    {
        win.SetActive(false);
    }
    private void Update()
    {
        DisplayProgress();
        if (progress == maxProgress)
        {
            Win();
        }
    }

    private void DisplayProgress()
    {
        progressImage.fillAmount = (float)progress / (float)maxProgress;
    }

    public void AddProgress()
    {
        progress += addProgess;
    }

    public void Win()
    {
        win.SetActive(true);
    }
}

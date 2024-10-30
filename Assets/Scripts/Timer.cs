using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image timerBar; 
    [SerializeField] private GameObject retry;
    [SerializeField] private GameObject win;
    [SerializeField] private TMP_Text timerText;

    [Header("Set Time")]
    public float time = 60.0f;
    public float minusTime = 5;
    private float timeLeft;
    private void Awake()
    {
        timeLeft = time;
        retry.SetActive(false);
    }

    void Update()
    {

        if (timeLeft >= 0.0f && win.activeInHierarchy == false)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / time;
        }
        else if (win.activeInHierarchy == true)
        {
            return;
        }
        else
        {
            TimeUp();
            timeLeft = 0.0f;
        }
        timerText.text = "" + ((int)timeLeft);
    }

    private void TimeUp()
    {
        retry.SetActive(true);
    }

    public void DecreaseTime()
    {
        timeLeft -= minusTime;
    }
}

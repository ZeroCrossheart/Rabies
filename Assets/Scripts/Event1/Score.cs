using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int currentScore;

    [SerializeField] private int scoreValue = 100;
    [SerializeField] private int winScore = 400;

    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private GameObject win;

    void Awake()
    {
        win.SetActive(false);
        currentScore = 0;
    }

    public void ShowScore()
    {
        /*scoreText.text = "Score : " + currentScore;*/
        if (currentScore == winScore)
        {
            win.SetActive(true);
        }
    }

    public void AddScore()
    {
        currentScore += scoreValue;
    }
}

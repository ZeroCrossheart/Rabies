using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] dogs;
    [SerializeField] private GameObject[] infectedDogs;
    [SerializeField] private GameObject[] curedDogs;

    [SerializeField] private TMP_Text normalCount;
    [SerializeField] private TMP_Text goodCount;
    [SerializeField] private TMP_Text badCount;

    public GameObject gameOverPanel;
    public GameObject nextStageButton;
    public GameObject retryButton;
    public TMP_Text resultText;

    private void Awake()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }

    void Update()
    {
        dogs = GameObject.FindGameObjectsWithTag("Normal");
        infectedDogs = GameObject.FindGameObjectsWithTag("DogInfected");
        curedDogs = GameObject.FindGameObjectsWithTag("DogCured");
        CheckGameOverCondition();
        normalCount.text = ("") + dogs.Count();
        goodCount.text = ("") + curedDogs.Count();
        badCount.text = ("") + infectedDogs.Count();
    }

    void CheckGameOverCondition()
    {
        if (dogs.Count() <= 0)
        {
            ShowGameOverScreen();
        }
    }

    void ShowGameOverScreen()
    {
        gameOverPanel.SetActive(true);

        if (curedDogs.Count() > infectedDogs.Count())
        {
            resultText.text = "คุณชนะ!\n สุนัขที่ได้รับวัคซีน: " + curedDogs.Count() + "\n สุนัขที่ติดเชื้อ: " + infectedDogs.Count();
            nextStageButton.SetActive(true);
        }
        else
        {
            resultText.text = "คุณแพ้!\n สุนัขที่ได้รับวัคซีน: " + curedDogs.Count() + "\n สุนัขที่ติดเชื้อ: " + infectedDogs.Count();
            retryButton.SetActive(true);
        }

        Time.timeScale = 0;
    }
}

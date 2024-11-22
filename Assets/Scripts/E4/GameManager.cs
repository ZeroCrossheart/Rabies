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
            resultText.text = "You Win!\n Cured Dogs: " + curedDogs.Count() + "\n Infected Dogs: " + infectedDogs.Count();
        }
        else
        {
            resultText.text = "You Lose!\n Cured Dogs: " + curedDogs.Count() + "\n Infected Dogs: " + infectedDogs.Count();
        }

        Time.timeScale = 0;
    }
}

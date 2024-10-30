using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    [Header("Next Scene")]
    [SerializeField] private string nextScene;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
        Time.timeScale = 1.0f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}

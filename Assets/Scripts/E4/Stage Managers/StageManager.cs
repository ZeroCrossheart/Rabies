using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.EventTrigger;

public class StageManager : MonoBehaviour
{
    [Header("Next Scene")]
    [SerializeField] private string nextScene;
    private string currentSceneName;

    private void Start()
    {
        void Start()
        {
            currentSceneName = SceneManager.GetActiveScene().name;
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
        Time.timeScale = 1.0f;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneName);
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }


    public void Quit()
    {
        Application.Quit();
    }
}

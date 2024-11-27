using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    private string currentSceneName;
    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    public void ReloadScene()
    {
        source.clip = clip;
        source.Play();
        SceneManager.LoadScene(currentSceneName);
        if(Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }
}

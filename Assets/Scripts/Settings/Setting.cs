using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;

    public void BackToMenu()
    {
        pauseScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
}

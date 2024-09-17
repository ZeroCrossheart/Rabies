using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    private Sprite thisButtonSprite;
    [Header("Decrease Time")]
    [SerializeField] private float minusTime = 10;

    [Header("Objects References")]
    [SerializeField] private GameObject gameController;
    [SerializeField] private GameObject vaccine;
    [SerializeField] private GameObject retry;
    [SerializeField] private GameObject win;

    private VaccineProgress vaccineProgress;
    private GameController controller;
    private Timer timer;

    [Header("Sprites")]
    [SerializeField] private Sprite right;
    [SerializeField] private Sprite wrong;

    private void Awake()
    {
        controller = gameController.GetComponent<GameController>();
        timer = gameController.GetComponent<Timer>();
        vaccineProgress = vaccine.GetComponent<VaccineProgress>();
    }

    private void Update()
    {
        thisButtonSprite = this.GetComponent<SpriteRenderer>().sprite;
    }

    public void OnMouseDown()
    {
        if (retry.activeInHierarchy == false && win.activeInHierarchy == false)
        {
            if (thisButtonSprite == right)
            {
                vaccineProgress.AddProgress();
                controller.ButtonsSwitch();
            }
            else
            {
                controller.ButtonsSwitch();
                timer.time -= minusTime;
                Debug.Log("Wrong");
            }
        }
        else
        {
            return;
        }

    }
}

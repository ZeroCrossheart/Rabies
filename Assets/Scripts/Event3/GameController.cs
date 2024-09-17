using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite[] faces;

    [Header("Buttons")]
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private float countStart = 5f;
    [SerializeField] private float countdown;

    [Header("Decrease Time")]
    [SerializeField] private GameObject gameController;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject retry;
    [SerializeField] private float minusTime = 10;
    private Timer timer;

    private int a;
    private int b;

    private Sprite right;
    private Sprite wrong;

    private GameObject button1;
    private GameObject button2;
    private GameObject button3;
    private GameObject button4;

    private int index;

    private void Awake()
    {
        countdown = countStart;
        timer = gameController.GetComponent<Timer>();
    }

    private void Update()
    {
        TooLateToPress();
    }

    private void Start()
    {
        right = faces[0];
        wrong = faces[1];

        button1 = buttons[0];
        button2 = buttons[1];
        button3 = buttons[2];
        button4 = buttons[3];

        index = Random.Range(1, 4);
        ButtonsSwitch();
    }

    public void ButtonsSwitch()
    {
        index = Random.Range(1, 5);
        while (a == index)
        {
            index = Random.Range(1, 5);
        }
        switch (index)
        {
            case 1:
                button1.GetComponent<SpriteRenderer>().sprite = right;
                button2.GetComponent<SpriteRenderer>().sprite = wrong;
                button3.GetComponent<SpriteRenderer>().sprite = wrong;
                button4.GetComponent<SpriteRenderer>().sprite = wrong;
                a = index;
                countdown = countStart;
                break;
            case 2:
                button1.GetComponent<SpriteRenderer>().sprite = wrong;
                button2.GetComponent<SpriteRenderer>().sprite = right;
                button3.GetComponent<SpriteRenderer>().sprite = wrong;
                button4.GetComponent<SpriteRenderer>().sprite = wrong;
                a = index;
                countdown = countStart;
                break;
            case 3:
                button1.GetComponent<SpriteRenderer>().sprite = wrong;
                button2.GetComponent<SpriteRenderer>().sprite = wrong;
                button3.GetComponent<SpriteRenderer>().sprite = right;
                button4.GetComponent<SpriteRenderer>().sprite = wrong;
                a = index;
                countdown = countStart;
                break;
            case 4:
                button1.GetComponent<SpriteRenderer>().sprite = wrong;
                button2.GetComponent<SpriteRenderer>().sprite = wrong;
                button3.GetComponent<SpriteRenderer>().sprite = wrong;
                button4.GetComponent<SpriteRenderer>().sprite = right;
                a = index;
                countdown = countStart;
                break;
        }

        Debug.Log("Index = " + index);
    }

    private void TooLateToPress()
    {
        if (retry.activeInHierarchy == false && win.activeInHierarchy == false)
        {
            if (countdown > 0)
            {
                countdown -= Time.deltaTime;
            }
            else
            {
                ButtonsSwitch();
                timer.time -= minusTime;
                countdown = countStart;
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class NewE2GameController : MonoBehaviour
{
    [SerializeField] private GameObject retry;
    [SerializeField] private GameObject win;

    [Header("")]
    [SerializeField] private TMP_Text[] instructionList;

    [Header("")]
    [SerializeField] private Timer timer;

    public int score;

    private ClickedItem clickedItem;

    void Start()
    {
        score = 0;
        clickedItem = ClickedItem.none;
        /*StartCoroutine(SpawnItem());*/
    }
    private void Update()
    {
        CheckItem();
        /*Debug.Log(clickedItem);
        Debug.Log(score);*/
    }

    public ClickedItem ChangeClickedItem(ClickedItem clickedSprite)
    {
        clickedItem = clickedSprite;
        return clickedSprite;
    }

    private void CheckItem()
    {
        if (score == 0)
        {
            if (clickedItem == ClickedItem.water)
            {
                instructionList[score].color = Color.green;
                score += 1;
                clickedItem = ClickedItem.none;

            }
            else if (clickedItem != ClickedItem.none)
            {
                timer.DecreaseTime();
                clickedItem = ClickedItem.none;
                /*instructionList[0].color = Color.red;*/
            }
            else
            {
                return;
            }
        }
        else if (score == 1)
        {
            if (clickedItem == ClickedItem.soap)
            {
                score += 1;
                clickedItem = ClickedItem.none;
                instructionList[1].color = Color.green;
            }
            else if (clickedItem != ClickedItem.none)
            {
                timer.DecreaseTime();
                clickedItem = ClickedItem.none;
            }
            else if (clickedItem != ClickedItem.none)
            {
                return;
            }
        }
        else if (score == 2)
        {
            if (clickedItem == ClickedItem.gauze)
            {
                score += 1;
                clickedItem = ClickedItem.none;
                instructionList[2].color = Color.green;
            }
            else if (clickedItem != ClickedItem.none)
            {
                timer.DecreaseTime();
                clickedItem = ClickedItem.none;
            }
            else if (clickedItem != ClickedItem.none)
            {
                return;
            }
        }
        else if (score == 3)
        {
            if (clickedItem == ClickedItem.towel)
            {
                score += 1;
                clickedItem = ClickedItem.none;
                instructionList[3].color = Color.green;
            }
            else if (clickedItem != ClickedItem.none)
            {
                timer.DecreaseTime();
                clickedItem = ClickedItem.none;
            }
            else
            {
                return;
            }
        }
        else if (score == 4)
        {
            if (clickedItem == ClickedItem.betadine)
            {
                score += 1;
                clickedItem = ClickedItem.none;
                instructionList[4].color = Color.green;
            }
            else if (clickedItem != ClickedItem.none)
            {
                timer.DecreaseTime();
                clickedItem = ClickedItem.none;
            }
            else
            {
                return;
            }
        }
        else if (score == 5)
        {
            win.SetActive(true);
        }
    }
}

public enum ClickedItem
{
    none,
    water,
    soap,
    gauze,
    towel,
    betadine,
    other,
}

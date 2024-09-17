using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class E2GameController : MonoBehaviour
{
    [SerializeField] private Sprite[] faces;
    [SerializeField] private GameObject[] cards;
    [SerializeField] private GameObject retry;
    [SerializeField] private GameObject win;
    public List<Sprite> clickedCards = new List<Sprite>();
    [SerializeField] private Health health;

    private Sprite face1;
    private Sprite face2;
    private Sprite face3;
    private Sprite face4;

    private int randNum;
    private int a;

    private void Awake()
    {
        face1 = faces[0];
        face2 = faces[1];
        face3 = faces[2];
        face4 = faces[3];

        ShuffleCards();
    }

    private void Update()
    {
        EndRetry();
        CheckOrder();
    }

    private void ShuffleCards()
    {
        randNum = UnityEngine.Random.Range(1, 5);
        while (a == randNum)
        {
            randNum = UnityEngine.Random.Range(1, 5);
        }
        switch (randNum)
        {
            case 1:
                cards[0].GetComponent<SpriteRenderer>().sprite = faces[0];
                cards[1].GetComponent<SpriteRenderer>().sprite = faces[1];
                cards[2].GetComponent<SpriteRenderer>().sprite = faces[2];
                cards[3].GetComponent<SpriteRenderer>().sprite = faces[3];
                cards[4].GetComponent<SpriteRenderer>().sprite = faces[4];
                cards[5].GetComponent<SpriteRenderer>().sprite = faces[5];
                a = randNum;
                break;
            case 2:
                cards[0].GetComponent<SpriteRenderer>().sprite = faces[5];
                cards[1].GetComponent<SpriteRenderer>().sprite = faces[3];
                cards[2].GetComponent<SpriteRenderer>().sprite = faces[4];
                cards[3].GetComponent<SpriteRenderer>().sprite = faces[0];
                cards[4].GetComponent<SpriteRenderer>().sprite = faces[2];
                cards[5].GetComponent<SpriteRenderer>().sprite = faces[1];
                a = randNum;
                break;
            case 3:
                cards[0].GetComponent<SpriteRenderer>().sprite = faces[1];
                cards[1].GetComponent<SpriteRenderer>().sprite = faces[5];
                cards[2].GetComponent<SpriteRenderer>().sprite = faces[3];
                cards[3].GetComponent<SpriteRenderer>().sprite = faces[4];
                cards[4].GetComponent<SpriteRenderer>().sprite = faces[0];
                cards[5].GetComponent<SpriteRenderer>().sprite = faces[2];
                a = randNum;
                break;
            case 4:
                cards[0].GetComponent<SpriteRenderer>().sprite = faces[1];
                cards[1].GetComponent<SpriteRenderer>().sprite = faces[4];
                cards[2].GetComponent<SpriteRenderer>().sprite = faces[3];
                cards[3].GetComponent<SpriteRenderer>().sprite = faces[0];
                cards[4].GetComponent<SpriteRenderer>().sprite = faces[5];
                cards[5].GetComponent<SpriteRenderer>().sprite = faces[2];
                a = randNum;
                break;
        }
    }

    public void AddSelected(Sprite s)
    {
        if (retry.activeInHierarchy == false && win.activeInHierarchy == false)
        {
            clickedCards.Add(s);
        }
    }

    private void CheckOrder()
    {
        if(clickedCards.Count == 4)
        {
            if (clickedCards[0] == faces[0] &&
            clickedCards[1] == faces[1] &&
            clickedCards[2] == faces[2] &&
            clickedCards[3] == faces[3])
            {
                Debug.Log("Win");
                win.SetActive(true);
                clickedCards.Clear();
            }
            else
            {
                Debug.Log("Wrong Order");
                for(int i = 0; i < 6;i++)
                {
                    cards[i].GetComponent<Cards>().DeactiveBorder();
                }
                clickedCards.Clear();
                health.Damage();
            }
        }
    }

    private void EndRetry()
    {
        if(health.health == 0)
        {
            retry.SetActive(true);
            for (int i = 0; i < 6; i++)
            {
                cards[i].GetComponent<Cards>().enabled = false;
            }
        }
    }
}

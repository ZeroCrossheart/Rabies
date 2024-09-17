using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameControlEasy : MonoBehaviour
{
    GameObject card;
    GameObject clickedCardsList;
    GameObject score;
    private GameObject card1;
    private GameObject card2;
    [SerializeField] private Timer timer;
    [SerializeField] private MarkTextInGreen MarkTextInGreen;

    List<int> faceIndexes = new List<int> { 0, 1, 2, 0, 1, 2};
    public List<GameObject> selectedCards = new List<GameObject>();
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    int[] visibleFaces = { -1, -2 };


    void Start()
    {
        int originalLenght = faceIndexes.Count; 

        float yPosition = 3f;
        float xPosition = -5.29f;

        for (int i = 0; i < 5; i++)
        {
            shuffleNum = rnd.Next(faceIndexes.Count);

            var temp = Instantiate(card, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
            temp.GetComponent<MainCardEasy>().faceIndex = faceIndexes[shuffleNum];
            faceIndexes.Remove(faceIndexes[shuffleNum]);
            xPosition = xPosition + 2;
            if ( i == 1)
            {
                yPosition = 1f;
                xPosition = -7.29f;
            }
        }
        card.GetComponent<MainCardEasy>().faceIndex = faceIndexes[0];

        
    }

    public void AddOrRemove(GameObject s)
    {
        if (selectedCards.Contains(s))
        {
            return;
        }
        else
        {
            selectedCards.Add(s);
        }
            
    }

    public bool TwoCardsUp()
    {
        bool cardsUp = false;
        if (visibleFaces[0] >= 0 && visibleFaces[1] >= 0)
        {
            selectedCards.Clear();
            cardsUp = true;
            
        }
        return cardsUp;
    }

    public void AddVisibleFace(int index)
    {
        if (visibleFaces[0] == -1)
        {
            visibleFaces[0] = index;
        }
        else if (visibleFaces[1] == -2)
        {
            visibleFaces[1] = index;
        }
    }

    public void RemoveVisibleFace(int index) 
    {
        if (visibleFaces[0] == index)
        {
            visibleFaces[0] = -1;
        }
        else if (visibleFaces[1] == index)
        {
            visibleFaces[1] = -2;
        }
    }

    public bool CheckMatch()
    {
        bool success = false;
        if (visibleFaces[0] == visibleFaces[1])
        {
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            success = true;
            score.GetComponent<Score>().AddScore();
            score.GetComponent<Score>().ShowScore();

            card1 = selectedCards[0];
            card2 = selectedCards[1];
            card1.GetComponent<MainCardEasy>().DisableCollider();
            card2.GetComponent<MainCardEasy>().DisableCollider();
            if (card1.GetComponent<MainCardEasy>().faceIndex ==  0)
            {
                MarkTextInGreen.MarkPro0InGreen();
            }
            else if (card1.GetComponent<MainCardEasy>().faceIndex == 1)
            {
                MarkTextInGreen.MarkPro1InGreen();
            }
            else if (card1.GetComponent<MainCardEasy>().faceIndex == 2)
            {
                MarkTextInGreen.MarkPro2InGreen();
            }
            else if (card1.GetComponent<MainCardEasy>().faceIndex == 3)
            {
                MarkTextInGreen.MarkPro3InGreen();
            }
            else if (card1.GetComponent<MainCardEasy>().faceIndex == 4)
            {
                MarkTextInGreen.MarkPro4InGreen();
            }
            else if (card1.GetComponent<MainCardEasy>().faceIndex == 5)
            {
                MarkTextInGreen.MarkPro5InGreen();
            }
            else if (card1.GetComponent<MainCardEasy>().faceIndex == 6)
            {
                MarkTextInGreen.MarkPro6InGreen();
            }
            else if (card1.GetComponent<MainCardEasy>().faceIndex == 7)
            {
                MarkTextInGreen.MarkPro7InGreen();
            }
            else if (card1.GetComponent<MainCardEasy>().faceIndex == 8)
            {
                MarkTextInGreen.MarkPro8InGreen();
            }
            else if (card1.GetComponent<MainCardEasy>().faceIndex == 9)
            {
                MarkTextInGreen.MarkPro9InGreen();
            }
            card1.GetComponent<MainCardEasy>().DisableCollider();
            card2.GetComponent<MainCardEasy>().DisableCollider();

            selectedCards.Clear();
        }
        else if (visibleFaces[0] != visibleFaces[1] && selectedCards.Count == 2 && success == false)
        {
            card1 = selectedCards[0];
            card2 = selectedCards[1];
            card1.GetComponent<MainCardEasy>().TurnCardsBackWithDelay();
            card2.GetComponent<MainCardEasy>().TurnCardsBackWithDelay();
            selectedCards.Clear();
            timer.DecreaseTime();
        }
        return success;
    }

    private void Awake()
    {
        card = GameObject.Find("CardBack");
        clickedCardsList = GameObject.Find("GameController");
        score = GameObject.Find("GameController");
    }
}

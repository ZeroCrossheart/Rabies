using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameControlHard : MonoBehaviour
{
    GameObject card;
    GameObject clickedCardsList;
    GameObject score;
    private GameObject card1;
    private GameObject card2;
    [SerializeField] private Timer timer;
    [SerializeField] private MarkTextInGreen MarkTextInGreen;

    [SerializeField] private SFXPlayer soundPlayer;

    List<int> faceIndexes = new List<int> { 0, 1, 2, 3, 4, 5, 0, 1, 2, 3, 4, 5};
    public List<GameObject> selectedCards = new List<GameObject>();
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    int[] visibleFaces = { -1, -2 };


    void Start()
    {
        int originalLenght = faceIndexes.Count; 

        float yPosition = 2.4f;
        float xPosition = -4f;

        for (int i = 0; i < 11; i++)
        {
            shuffleNum = rnd.Next(faceIndexes.Count);

            var temp = Instantiate(card, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
            temp.GetComponent<MainCardHard>().faceIndex = faceIndexes[shuffleNum];
            faceIndexes.Remove(faceIndexes[shuffleNum]);
            xPosition = xPosition + 2.5f;
            if ( i == 2)
            {
                yPosition = -0.62f;
                xPosition = -6.5f;
            }
            else if ( i == 6) 
            {
                yPosition = -3.64f;
                xPosition = -6.5f;
            }
        }
        card.GetComponent<MainCardHard>().faceIndex = faceIndexes[0];
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
            soundPlayer.CorrectMatchEffect();
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            success = true;
            score.GetComponent<Score>().AddScore();
            score.GetComponent<Score>().ShowScore();

            card1 = selectedCards[0];
            card2 = selectedCards[1];
            card1.GetComponent<MainCardHard>().DisableCollider();
            card2.GetComponent<MainCardHard>().DisableCollider();
            if (card1.GetComponent<MainCardHard>().faceIndex ==  0)
            {
                MarkTextInGreen.MarkPro0InGreen();
            }
            else if (card1.GetComponent<MainCardHard>().faceIndex == 1)
            {
                MarkTextInGreen.MarkPro1InGreen();
            }
            else if (card1.GetComponent<MainCardHard>().faceIndex == 2)
            {
                MarkTextInGreen.MarkPro2InGreen();
            }
            else if (card1.GetComponent<MainCardHard>().faceIndex == 3)
            {
                MarkTextInGreen.MarkPro3InGreen();
            }
            else if (card1.GetComponent<MainCardHard>().faceIndex == 4)
            {
                MarkTextInGreen.MarkPro4InGreen();
            }
            else if (card1.GetComponent<MainCardHard>().faceIndex == 5)
            {
                MarkTextInGreen.MarkPro5InGreen();
            }
            else if (card1.GetComponent<MainCardHard>().faceIndex == 6)
            {
                MarkTextInGreen.MarkPro6InGreen();
            }
            else if (card1.GetComponent<MainCardHard>().faceIndex == 7)
            {
                MarkTextInGreen.MarkPro7InGreen();
            }
            else if (card1.GetComponent<MainCardHard>().faceIndex == 8)
            {
                MarkTextInGreen.MarkPro8InGreen();
            }
            else if (card1.GetComponent<MainCardHard>().faceIndex == 9)
            {
                MarkTextInGreen.MarkPro9InGreen();
            }
            card1.GetComponent<MainCardHard>().DisableCollider();
            card2.GetComponent<MainCardHard>().DisableCollider();

            selectedCards.Clear();
        }
        else if (visibleFaces[0] != visibleFaces[1] && selectedCards.Count == 2 && success == false)
        {
            soundPlayer.WrongMatchEffect();
            card1 = selectedCards[0];
            card2 = selectedCards[1];
            card1.GetComponent<MainCardHard>().TurnCardsBackWithDelay();
            card2.GetComponent<MainCardHard>().TurnCardsBackWithDelay();
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

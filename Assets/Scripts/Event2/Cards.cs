using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    [SerializeField] private E2GameController controller;
    [SerializeField] private GameObject cardBorder;
    [SerializeField] private GameObject retry;
    [SerializeField] private GameObject win;
    private List<Sprite> clickedCards = new List<Sprite>();

    private Sprite thisSprite;

    private void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>().sprite;
    }

    public void OnMouseDown()
    {
        if(controller.clickedCards.Count == 4) 
        {
            Debug.Log("Full");
        }
        else
        {
            if (retry.activeInHierarchy == false && win.activeInHierarchy == false)
            {
                ActiveBorder();
                controller.AddSelected(thisSprite);
            }
        }
    }

    public void ActiveBorder()
    {
        cardBorder.SetActive(true);
    }
    public void DeactiveBorder()
    {
        cardBorder.SetActive(false);
    }
}

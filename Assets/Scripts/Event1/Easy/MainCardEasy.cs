using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCardEasy : MonoBehaviour
{
    GameObject gameControl;
    [SerializeField] private GameObject retry;

    SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite[] faces;
    [SerializeField] private Sprite back;

    public int faceIndex;
    public bool matched = false;

    public void Start()
    {
        Invoke("TurnCardsOverWithDelay", 0.1f);
    }

    public void OnMouseDown()
    {
        if (retry.activeInHierarchy == false)
        {
            if (matched == false)
            {
                if (spriteRenderer.sprite == back)
                {
                    if (gameControl.GetComponent<GameControlEasy>().TwoCardsUp() == false)
                    {
                        gameControl.GetComponent<GameControlEasy>().AddOrRemove(gameObject);
                        spriteRenderer.sprite = faces[faceIndex];
                        gameControl.GetComponent<GameControlEasy>().AddVisibleFace(faceIndex);
                        matched = gameControl.GetComponent<GameControlEasy>().CheckMatch();
                        Debug.Log("A card was clicked");
                    }
                }

                // Turn cards back with click.(Not used rigth now)
                /*else
                {
                    spriteRenderer.sprite = back;
                    gameControl.GetComponent<GameControl>().RemoveVisibleFace(faceIndex);
                    Debug.Log("A card was clicked");
                }*/
            }
        }
        else
        {
            return;
        }

    }
    private void Awake()
    {
        gameControl = GameObject.Find("GameController");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DisableCollider()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void TurnCardsBack()
    {
        spriteRenderer.sprite = back;
        gameControl.GetComponent<GameControlEasy>().RemoveVisibleFace(faceIndex);

    }

    public void TurnCardsBackWithDelay()
    {
        Invoke("TurnCardsBack", 1f);
    }

    public void TurnCardsBackWithMoreDelay()
    {
        Invoke("TurnCardsBack", 3f);
    }

    public void TurnCardOver()
    {
        spriteRenderer.sprite = faces[faceIndex];
        gameControl.GetComponent<GameControlEasy>().AddVisibleFace(faceIndex);
    }

    public void TurnCardsOverWithDelay()
    {
        TurnCardOver();
        TurnCardsBackWithMoreDelay();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCardNormal : MonoBehaviour
{
    GameObject gameControl;
    [SerializeField] private GameObject retry;

    SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite[] faces;
    [SerializeField] private Sprite back;

    public int faceIndex;
    public bool matched = false;

    

    public void OnMouseDown()
    {
        if (retry.activeInHierarchy == false)
        {
            if (matched == false)
            {
                if (spriteRenderer.sprite == back)
                {
                    if (gameControl.GetComponent<GameControlNormal>().TwoCardsUp() == false)
                    {
                        gameControl.GetComponent<GameControlNormal>().AddOrRemove(gameObject);
                        spriteRenderer.sprite = faces[faceIndex];
                        gameControl.GetComponent<GameControlNormal>().AddVisibleFace(faceIndex);
                        matched = gameControl.GetComponent<GameControlNormal>().CheckMatch();
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
        gameControl.GetComponent<GameControlNormal>().RemoveVisibleFace(faceIndex);

    }

    public void TurnCardsBackWithDelay()
    {
        Invoke("TurnCardsBack", 1f);
    }
}

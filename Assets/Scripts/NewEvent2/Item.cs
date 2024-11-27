using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("")]
    [SerializeField] private GameObject controller;
    private NewE2GameController gameController;

    [Header("")]
    public Sprite[] itemSprites;
    private int randomSpriteIndex;

    [Header("")]
    [SerializeField] private float moveSpeed = 0.05f;
    [SerializeField] private float timeout = 5f;
    [SerializeField] private float timeToDestroy = 0.5f;

    [Header("")]
    [SerializeField] private GameObject right;
    [SerializeField] private GameObject wrong;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject tutorialOverlay;

    private GameObject canvas;
    private GameObject win;
    private GameObject retry;

    void Start()
    {
        right.SetActive(false);
        wrong.SetActive(false);
        controller = GameObject.Find("GameController");
        canvas = GameObject.Find("UI");
        win = canvas.transform.Find("Win").gameObject;
        retry = canvas.transform.Find("Retry").gameObject;
        pause = canvas.transform.Find("PauseOverlay").gameObject;
        setting = canvas.transform.Find("SettingOverlay").gameObject;
        tutorialOverlay = canvas.transform.Find("TutorialOverlay").gameObject;
        gameController = controller.GetComponent<NewE2GameController>();
        randomSpriteIndex = UnityEngine.Random.Range(0, itemSprites.Count());
        GetComponent<SpriteRenderer>().sprite = itemSprites[randomSpriteIndex];
        StartCoroutine(Timeout());
    }

    void FixedUpdate()
    {
        transform.Translate(0, -moveSpeed, 0);
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(timeout);
        Destroy(this.gameObject);
    }

    private void OnMouseDown()
    {
        if (retry.activeInHierarchy == false && win.activeInHierarchy == false && right.activeInHierarchy == false && wrong.activeInHierarchy == false && pause.activeInHierarchy == false && setting.activeInHierarchy == false
            && tutorialOverlay.activeInHierarchy == false)
        {
            ClickedSprite();
            ChangeHighlight();
            Debug.Log("An item was clicked.");
        }
    }

    private void ClickedSprite()
    {
        if (GetComponent<SpriteRenderer>().sprite == itemSprites[0])
        {
            gameController.ChangeClickedItem(ClickedItem.water);
        }
        else if (GetComponent<SpriteRenderer>().sprite == itemSprites[1])
        {
            gameController.ChangeClickedItem(ClickedItem.soap);
        }
        else if (GetComponent<SpriteRenderer>().sprite == itemSprites[2])
        {
            gameController.ChangeClickedItem(ClickedItem.gauze);
        }
        else if (GetComponent<SpriteRenderer>().sprite == itemSprites[3])
        {
            gameController.ChangeClickedItem(ClickedItem.towel);
        }
        else if (GetComponent<SpriteRenderer>().sprite == itemSprites[4])
        {
            gameController.ChangeClickedItem(ClickedItem.betadine);
        }
        else
        {
            gameController.ChangeClickedItem(ClickedItem.other);
        }
    }

    private void ChangeHighlight()
    {
        if (gameController.score == 0)
        {
            if (GetComponent<SpriteRenderer>().sprite == itemSprites[0])
            {
                right.SetActive(true);
                Destroy(this.gameObject, timeToDestroy);
            }
            else
            {
                wrong.SetActive(true);
                Destroy(this.gameObject, timeToDestroy);
            }
        }
        else if (gameController.score == 1)
        {
            if (GetComponent<SpriteRenderer>().sprite == itemSprites[1])
            {
                right.SetActive(true);
                Destroy(this.gameObject, timeToDestroy);
            }
            else
            {
                wrong.SetActive(true);
                Destroy(this.gameObject, timeToDestroy);
            }
        }
        else if (gameController.score == 2)
        {
            if (GetComponent<SpriteRenderer>().sprite == itemSprites[2])
            {
                right.SetActive(true);
                Destroy(this.gameObject, timeToDestroy);
            }
            else
            {
                wrong.SetActive(true);
                Destroy(this.gameObject, timeToDestroy);
            }
        }
        if (gameController.score == 3)
        {
            if (GetComponent<SpriteRenderer>().sprite == itemSprites[3])
            {
                right.SetActive(true);
                Destroy(this.gameObject, timeToDestroy);
            }
            else
            {
                wrong.SetActive(true);
                Destroy(this.gameObject, timeToDestroy);
            }
        }
        if (gameController.score == 4)
        {
            if (GetComponent<SpriteRenderer>().sprite == itemSprites[4])
            {
                right.SetActive(true);
                Destroy(this.gameObject, timeToDestroy);
            }
            else
            {
                wrong.SetActive(true);
                Destroy(this.gameObject, timeToDestroy);
            }
        }
    }
}

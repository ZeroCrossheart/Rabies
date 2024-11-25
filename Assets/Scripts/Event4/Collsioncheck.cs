using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collsioncheck : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private GameObject gameManager;
    private GameManager manager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.tag == "Normal")
        {
            if (other.CompareTag("Player"))
            {
                this.GetComponent<SpriteRenderer>().sprite = sprites[0];
            }
            else if (other.CompareTag("Infected"))
            {
                this.GetComponent<SpriteRenderer>().sprite = sprites[1];
            }
        }

        /*if (this.gameObject.tag != "DogInfected" && this.gameObject.tag != "DogCured")
        {
            if (other.CompareTag("Player"))
            {
                this.GetComponent<SpriteRenderer>().sprite = sprites[0];
            }
            else if (other.CompareTag("Infected"))
            {
                this.GetComponent<SpriteRenderer>().sprite = sprites[1];
            }
        }*/
/*        else if (this.gameObject.tag == "DogInfected")
        {
            return;
        }*/
    }
}
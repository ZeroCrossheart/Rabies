using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<GameObject> targetDog = new List<GameObject>();
    [SerializeField] private List<GameObject> dogInfected = new List<GameObject>();
    [SerializeField] private Sprite infectedSprite;
    [SerializeField] private GameObject gameManager;
    private GameManager manager;

    private int ran;

    NavMeshAgent agent;

    private void Start()
    {
        targetDog = (GameObject.FindGameObjectsWithTag("Normal")).ToList();
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<GameManager>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        FindNextEnemy();
    }
    void Update()
    {
        dogInfected = (GameObject.FindGameObjectsWithTag("DogInfected")).ToList();

        /*Debug.Log("There are " + enemyDog.Count() + " Ran = " + ran);*/

        if (targetDog.Count() > 0)
        {
            agent.SetDestination(targetDog[ran].transform.position);
        }
        else
        {
            return;
        }

    }

    private void FindNextEnemy()
    {
        if (targetDog.Count() != 0)
        {
            ran = UnityEngine.Random.Range(1, targetDog.Count()) - 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "Normal")
        {
            /*Debug.Log("Hit");
            Debug.Log(other.gameObject.name);*/
            other.GetComponent<SpriteRenderer>().sprite = infectedSprite;
            targetDog.Remove(other);
            other.gameObject.tag = "DogInfected";
            FindNextEnemy();
        }
        else if (other.tag == "DogCured")
        {
            targetDog.Remove(other);
            FindNextEnemy();
        }
    }
}

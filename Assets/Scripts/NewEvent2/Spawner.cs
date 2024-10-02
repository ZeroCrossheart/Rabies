using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.EventSystems.EventTrigger;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject retry;
    [SerializeField] private GameObject win;

    [Header("")]
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject spawner;
    [SerializeField] private float spawnWaitTime = 2f;

    private void Start()
    {
        StartCoroutine(SpawnItem());
    }

    IEnumerator SpawnItem()
    {
        while (retry.activeInHierarchy == false && win.activeInHierarchy == false)
        {
            yield return new WaitForSeconds(spawnWaitTime);
            Instantiate(item, spawner.transform.position, Quaternion.identity);
        }
    }
}

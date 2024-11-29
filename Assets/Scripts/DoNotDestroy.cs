using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    [SerializeField] private GameObject[] go;

    private void Awake()
    {

        go = GameObject.FindGameObjectsWithTag("Music");

        if (go.Count() > 1)
        {
            Destroy(go[0]);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}

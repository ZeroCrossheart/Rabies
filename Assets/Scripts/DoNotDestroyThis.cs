using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyThis : MonoBehaviour
{   
    private void Awake()
    {
        GameObject gameObject = this.gameObject;
        DontDestroyOnLoad(gameObject);
    }
}

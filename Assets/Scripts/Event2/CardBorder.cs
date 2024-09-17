using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBorder : MonoBehaviour
{
    public Color startColor;
    void Awake()
    {
        startColor = gameObject.GetComponent<Renderer>().material.color;
    }

    public void OnMouseDown()
    {
        startColor = Color.red;
    }
}

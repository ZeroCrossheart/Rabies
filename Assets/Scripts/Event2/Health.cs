using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 3;

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite heart;

    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++) 
        {
            if(i < health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void Damage()
    {
        health--;
    }
}

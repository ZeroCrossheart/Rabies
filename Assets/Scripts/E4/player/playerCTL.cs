using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCTL : MonoBehaviour
{
    [SerializeField] private MovementJoystick joystick;
    [SerializeField] private float speed = 3f;
    private Rigidbody2D rb;

    [SerializeField] private Sprite curedSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        if (joystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(joystick.joystickVec.x * speed, joystick.joystickVec.y * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.gameObject.tag == "Normal")
        {
            other.GetComponent<SpriteRenderer>().sprite = curedSprite;
            other.gameObject.tag = "DogCured";
        }
    }
}

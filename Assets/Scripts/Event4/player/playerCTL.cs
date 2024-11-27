using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCTL : MonoBehaviour
{
    [SerializeField] private E4SFX sound;

    [SerializeField] private Animator animator;

    [SerializeField] private MovementJoystick joystick;
    [SerializeField] private float speed = 3f;

    [SerializeField] private bool isMoving = false;
    private Rigidbody2D rb;

    [SerializeField] private Sprite curedSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        if (joystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(joystick.joystickVec.x * speed, joystick.joystickVec.y * speed);

            if (joystick.joystickVec != Vector2.zero)
            {
                isMoving = true;
                animator.SetBool("isWalking", isMoving);
                animator.SetFloat("XInput", joystick.joystickVec.x);
                animator.SetFloat("YInput", joystick.joystickVec.y);
            }       
        }
        else
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("isWalking", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.gameObject.tag == "Normal")
        {
            sound.CureEffect();
            other.GetComponent<SpriteRenderer>().sprite = curedSprite;
            other.gameObject.tag = "DogCured";
        }
    }
}

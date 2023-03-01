using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Vector3 movement;

    public Animator playerAnimator;
    private Rigidbody2D rb;
    public FixedJoystick fixedJoystick;

    private float horizontal;
    private float vertical;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal =  fixedJoystick.Horizontal;
        vertical = fixedJoystick.Vertical;

        movement = new Vector3(horizontal, vertical, 0.0f);

        playerAnimator.SetFloat("moveX", movement.x);
        playerAnimator.SetFloat("moveY", movement.y);
        playerAnimator.SetFloat("Magnitude", movement.magnitude);

        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }

    void OnTriggerEnter2D()
    {
        transform.position = transform.position + new Vector3(0, 0, 0.2f);
    }

    void OnTriggerExit2D()
    {
        transform.position = transform.position + new Vector3(0, 0, -0.2f);
    }
}
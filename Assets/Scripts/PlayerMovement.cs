using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D rb;
    public Vector2 movement;
    public bool disabled = false;

    void Update()
    {
        if (!disabled) {
            Movement();
        }
    }

    private void Movement() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.magnitude > 1.0f) {
            movement.Normalize();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public void setDisabled(bool disabled) {
        this.disabled = disabled;
    }
}

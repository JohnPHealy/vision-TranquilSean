using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIPatrol : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D bodyCollider;
    public LayerMask wallLayer;
    public float walkSpeed;

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if(bodyCollider.IsTouchingLayers(wallLayer))
        {
            Flip();
        }
        //Movement
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
    }
}

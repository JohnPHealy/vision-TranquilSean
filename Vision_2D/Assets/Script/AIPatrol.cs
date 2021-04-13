using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIPatrol : MonoBehaviour
{
    const string RIGHT = "right";
    const string LEFT = "left";
    const string UP = "up";
    const string DOWN = "down";
    
    public Rigidbody2D rb;
    public Collider2D bodyCollider;
    public Collider2D fov;
    public GameObject player;
    public LayerMask playerLayer;
    public LayerMask wallLayer;
    public LayerMask patrolLayer;
    public float walkSpeed;
    [SerializeField] private GameManager manager;
    string facingDirection;
    
    private void Start()
    {
        facingDirection = RIGHT;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (bodyCollider.IsTouchingLayers(wallLayer) || bodyCollider.IsTouchingLayers(patrolLayer))
        {
            Flip();
        }

        if (fov.IsTouchingLayers(playerLayer))
        {
            manager.RespawnPlayer();
        }

        switch (facingDirection)
        {
            case RIGHT: 
                rb.rotation = 0; 
                rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, 0);
                break;
            case LEFT: 
                rb.rotation = 180;
                rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, 0);
                break;
            case UP: 
                rb.rotation = 90; 
                rb.velocity = new Vector2(0, walkSpeed * Time.fixedDeltaTime);
                break;
            case DOWN: 
                rb.rotation = 270;
                rb.velocity = new Vector2(0, walkSpeed * Time.fixedDeltaTime);
                break;
        }
    }

    void Flip()
    {
        switch (facingDirection)
        {
            case RIGHT:
                facingDirection = DOWN;
                walkSpeed *= -1;
                break;
            case DOWN:
                facingDirection = LEFT;
                break;
            case LEFT:
                facingDirection = UP;
                walkSpeed *= -1;
                break;
            case UP:
                facingDirection = RIGHT;
                break;
        }

        //transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        //walkSpeed *= -1;
        //transform.eulerAngles = Vector3.forward * 90;
    }
}
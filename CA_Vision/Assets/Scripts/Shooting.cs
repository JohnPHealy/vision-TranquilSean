using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    private SpriteRenderer mySprite;

    private void Start()
    {
        mySprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void Shoot(InputAction.CallbackContext context)
    {

        var bullet = Instantiate(projectile, transform.position, Quaternion.identity);
        var bulletMovement = bullet.GetComponent<ProjectileMovement>();
        if (mySprite.flipX) bulletMovement.SetDirection(-1);
        else bulletMovement.SetDirection(1);
        
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}

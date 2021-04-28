using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject player;
    public Transform teleportDestination;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == player.gameObject.name)
        {
            player.transform.position = teleportDestination.position;
        }
    }
}
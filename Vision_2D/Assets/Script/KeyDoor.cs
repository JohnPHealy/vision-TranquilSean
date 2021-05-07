using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        
    }
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}

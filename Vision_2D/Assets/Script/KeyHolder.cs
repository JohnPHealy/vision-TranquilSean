using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList;
    private int numRed, numBlue, numGold, numGreen;
    [SerializeField] private GameManager manager;

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Added Key:" + keyType);
        keyList.Add(keyType);
        
        if (keyType == Key.KeyType.Gold)
        {
            Debug.Log( keyType + "  " + numGold );
            manager.PickupKeyGold(1);
        }
        if (keyType == Key.KeyType.Red)
        {
            Debug.Log( keyType + "  " + numRed );
            manager.PickupKeyRed(1);
        }
        if (keyType == Key.KeyType.Blue)
        {
            Debug.Log( keyType + "  " + numBlue );
            manager.PickupKeyBlue(1);
        }
        if (keyType == Key.KeyType.Green)
        {
            Debug.Log( keyType + "  " + numGreen );
            manager.PickupKeyGreen(1);
        }
        
    }
    
    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
        if (keyType == Key.KeyType.Gold)
        {
            manager.PickupKeyGold(-1);
        }
        if (keyType == Key.KeyType.Red)
        {
            manager.PickupKeyRed(-1);
        }
        if (keyType == Key.KeyType.Blue)
        {
            manager.PickupKeyBlue(-1);
        }
        if (keyType == Key.KeyType.Green)
        {
            manager.PickupKeyGreen(-1);
        }
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    { 
        Key key = collider.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
            
        }else  Debug.Log("At door no key:");

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
            if (ContainsKey(keyDoor.GetKeyType()))
            {
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
                Debug.Log("Destroyed Key:");
            }
            
            

        }
    }
}

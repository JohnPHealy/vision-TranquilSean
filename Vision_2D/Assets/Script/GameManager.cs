using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private UnityEvent<string> addKey;
    private Vector3 startPos;
    public static  int keyNum;

    private void Start()
    {
        startPos = player.transform.position;
        keyNum = 0;
        UpdateUI();
        //PauseGame();

    }
    
    public void PickupKey()
    {
        keyNum += 1;
        UpdateUI();
    }
    private void UpdateUI()
    {
        addKey.Invoke(keyNum.ToString());
        
    }
    public void Checkpoint()
    {
        startPos = player.transform.position;
    }

    public void RespawnPlayer()
    {
        player.transform.position = startPos;
        
    }

    public void Teleport(Vector3 newPos)
    {
        player.transform.position = newPos;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }
}
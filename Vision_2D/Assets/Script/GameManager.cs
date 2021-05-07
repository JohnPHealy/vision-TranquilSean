using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private UnityEvent<string> addKey;
    [SerializeField] private UnityEvent<string> addGold;
    [SerializeField] private UnityEvent<string> addRed;
    [SerializeField] private UnityEvent<string> addBlue;
    [SerializeField] private UnityEvent<string> addGreen;
    private Vector3 startPos;
    public static  int keyNum, numBlue, numGreen, numGold, numRed;

    private void Start()
    {
        startPos = player.transform.position;
        numBlue = 0;
        numGreen = 0;
        numGold =0;
        numRed = 0;
        UpdateUI();
        PauseGame();

    }
    
    public void PickupKey(int num)
    {
        keyNum += num;
        UpdateUI();
    }

    public void PickupKeyGold(int num)
    {
        numGold += num;
        UpdateUI();
    }
    public void PickupKeyRed(int num)
    {
        numRed += num;
        UpdateUI();
    }
    public void PickupKeyBlue(int num)
    {
        numBlue += num;
        UpdateUI();
    }
    public void PickupKeyGreen(int num)
    {
        numGreen += num;
        UpdateUI();
    }
    private void UpdateUI()
    {
        addKey.Invoke(keyNum.ToString());
        addGold.Invoke(numGold.ToString());
        addRed.Invoke(numRed.ToString());
        addBlue.Invoke(numBlue.ToString());
        addGreen.Invoke(numGreen.ToString());
        
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
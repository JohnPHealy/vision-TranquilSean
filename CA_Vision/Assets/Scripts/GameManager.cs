using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private UnityEvent<string> updatePlayerScore;

    private Vector3 startPos;
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = player.transform.position;
        score = 0;
        UpdateUI();
        PauseGame();
    }

    public void RespawnPlayer()
    {
        player.transform.position = startPos;
        score = 0;
        UpdateUI();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateUI();
    }

    private void UpdateUI()
    {
        updatePlayerScore.Invoke(score.ToString());
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }
}

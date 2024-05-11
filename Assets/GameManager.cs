using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    // Game-related variables
    public int playerScore = 0;
    public int enemyScore = 0;

    private void Awake()
    {
        // Ensure there's only one instance of GameManager
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Function to increase player score
    public void IncreasePlayerScore(int points)
    {
        playerScore += points;
        Debug.Log("Player Score: " + playerScore);
    }

    // Function to increase enemy score
    public void IncreaseEnemyScore(int points)
    {
        enemyScore += points;
        Debug.Log("Enemy Score: " + enemyScore);
    }

    // Add more game-related functionality as needed
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int bestScore;
    public int score;
    public int currentLevel = 0;

    // Creates only a single instance of the GameManager
    public static GameManager singleton;

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);

        // Load the saved high score
        bestScore = PlayerPrefs.GetInt("HighScore");
    }

    public void NextLevel()
    {
        currentLevel++;
        FindObjectOfType<PlayerBallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadLevel(currentLevel);
    }

    public void RestartLevel()
    {
        // Show Ads to User
        // Advertisement.Show();

        singleton.score = 0;
        FindObjectOfType<PlayerBallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadLevel(currentLevel);
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;

        if (score > bestScore)
        {
            // To store the high score for the user
            PlayerPrefs.SetInt("HighScore", score);
            bestScore = score;
        }
    }
}

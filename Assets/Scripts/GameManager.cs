using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int bestScore;
    public int score;
    public int currentStage = 0;

    // Creates only a single instance of the GameManager
    public static GameManager singleton;

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);

        // // Load the saved highscore
        // bestScore = PlayerPrefs.GetInt("Highscore");
    }

    public void NextLevel()
    {
        // currentStage++;
        // FindObjectOfType<PlayerBallController>().ResetBall();
        // FindObjectOfType<HelixController>().LoadStage(currentStage);
    }

    public void RestartLevel()
    {
        // Debug.Log("Restarting Level");

        // Show Ads to User
        // Advertisement.Show();

        // singleton.score = 0;
        // FindObjectOfType<PlayerBallController>().ResetBall();
        // FindObjectOfType<HelixController>().LoadStage(currentStage);
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;

        if (score > bestScore)
        {
            // PlayerPrefs.SetInt("Highscore", score);
            bestScore = score;
        }
    }
}

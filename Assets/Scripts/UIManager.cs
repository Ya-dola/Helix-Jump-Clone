using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;

    void Update()
    {
        bestScoreText.text = "High Score: " + GameManager.singleton.bestScore;
        scoreText.text = "Score: " + GameManager.singleton.score;
    }
}

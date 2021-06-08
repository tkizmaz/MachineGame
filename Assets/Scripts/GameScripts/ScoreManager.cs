using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int score;
    private int highScore;
    // Start is called before the first frame update
    
    public int getScore()
    {
        return this.score;
    }

    public void incrementScore(int score)
    {
        this.score += score;
        UIManager.instance.UpdateScoreText(this.score);
    }

    private void Start()
    {
        this.score = 0;
        this.highScore = PlayerPrefs.GetInt("High Score", this.highScore);
        UIManager.instance.UpdateHighScoreText(this.highScore);
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= highScore)
        {
            highScore = score;
            UIManager.instance.UpdateHighScoreText(highScore);
            PlayerPrefs.SetInt("High Score", highScore);
            PlayerPrefs.Save();
        }
    }
}

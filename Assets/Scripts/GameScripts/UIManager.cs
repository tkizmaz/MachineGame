using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text timeText;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }


    private void UpdateTimeText()
    {
        timeText.text = TimeController.instance.getTime().ToString();
    }

    public void UpdateHighScoreText(int highScore)
    {
        highScoreText.text = highScore.ToString();
    }

    private void Start()
    {
        TimeController.instance.setTime(60f);
    }


    void Update()
    {
        TimeController.instance.BeginCountdown();
        UpdateTimeText();
    }
}

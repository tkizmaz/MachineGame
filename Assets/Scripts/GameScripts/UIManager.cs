using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text strikeText;
    [SerializeField] private Text timeText;
    private int score;
    private int strike;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        score += 50;
        scoreText.text = score.ToString();
    }

    public void UpdateStrikeText()
    {
        strike += 1;
        strikeText.text = strike.ToString();
    }

    private void UpdateTimeText()
    {
        timeText.text = TimeController.instance.getTime().ToString();
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

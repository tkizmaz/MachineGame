﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject platform;
    private Hole selectedHole;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Ball.CollisionEvent += ResetGame;
        Ball.GameOver += FinishGame;
        SelectRandomHole();
    }

    public void SetSelectedHole()
    {
        this.selectedHole.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        this.selectedHole.setIsTarget(true);
    }

    public void ResetSelectedHole()
    {
        this.selectedHole.setIsTarget(false);
        this.selectedHole.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        this.selectedHole = null;
    }

    public void SelectRandomHole()
    {
        Hole[] holeArray = Object.FindObjectsOfType<Hole>();
        int holeCount = holeArray.Length;
        int randomToChoose = (Random.Range(0, holeCount));
        this.selectedHole = holeArray[randomToChoose];
        SetSelectedHole();
    }

    private void ResetGame(GameObject ballObject)
    {
        ballObject.SetActive(false);
        platform.GetComponent<Platform>().ResetTransform();
        ballObject.GetComponent<Ball>().ResetTransform();
        ResetSelectedHole();
        SelectRandomHole();
        ballObject.SetActive(true);
        TimeController.instance.setTime(15f);
        ScoreManager.instance.incrementScore(10);
    }

    private void FinishGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    private void Update()
    {
        int timeRemaining = TimeController.instance.getTime();
        if(timeRemaining <= 0)
        {
            FinishGame();
        }

    }

}
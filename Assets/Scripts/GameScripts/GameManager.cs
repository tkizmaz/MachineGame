using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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

    public void SetSelectedHole(Hole selectedHole)
    {
        selectedHole.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        selectedHole.setIsTarget();
    }

    public void SelectRandomHole()
    {
        Hole[] holeArray = Object.FindObjectsOfType<Hole>();
        int holeCount = holeArray.Length;
        int randomToChoose = (Random.Range(0, holeCount));
        SetSelectedHole(holeArray[randomToChoose]);
    }

    private void ResetGame(GameObject ballObject)
    {
        Destroy(ballObject);
        TimeController.instance.setTime(15f);
        ScoreManager.instance.incrementScore(10);
    }

    private void FinishGame()
    {
        SceneManager.LoadScene("MainGame");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Platform platform;
    private Hole selectedHole;
    private List<Level> levelList;
    private int levelNumber;

    public void SetLevelList(List<Level> levelList)
    {
        this.levelList = levelList;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        levelNumber = 0;
        Ball.CollisionEvent += ResetGame;
        Ball.GameOver += FinishGame;
        SetLevelList(LevelManager.instance.GetLevelList());
        SetSelectedHole();
        UIManager.instance.UpdateLevelText(levelList[levelNumber].levelID);
        Debug.Log(levelList.Count);
    }

    private void OnDestroy()
    {
        Ball.CollisionEvent -= ResetGame;
        Ball.GameOver -= FinishGame;
    }

    private void SetSelectedHole()
    {
        this.selectedHole = levelList[levelNumber].GetSelectedHole().GetComponent<Hole>();
        this.selectedHole.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        this.selectedHole.setIsTarget(true);
    }

    private void ResetSelectedHole()
    {
        this.selectedHole.setIsTarget(false);
        this.selectedHole.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        this.selectedHole = null;
    }

    private void ResetGame(GameObject ballObject)
    {
        levelNumber++;
        ballObject.SetActive(false);
        platform.ResetTransform();
        ballObject.GetComponent<Ball>().ResetTransform();
        ballObject.SetActive(true);
        ResetSelectedHole();
        SetSelectedHole();
        TimeController.instance.setTime(LevelManager.instance.GetLevelList()[levelNumber].timeLimit);
        UIManager.instance.UpdateLevelText(levelList[levelNumber].levelID);
    }

    private void FinishGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void StartGame()
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
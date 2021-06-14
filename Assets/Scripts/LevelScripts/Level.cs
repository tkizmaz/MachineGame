using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript
{
    private GameObject selectedHole;
    private int levelID;
    private string levelDifficulty;
    private float timeLimit;

    public GameObject GetSelectedHole()
    {
        return this.selectedHole;
    }

    public void SetSelectedHole()
    {
        GameObject[] allDifficultyObjects = GameObject.FindGameObjectsWithTag(levelDifficulty);
        GameObject randomlySelected = allDifficultyObjects[Random.Range(0, allDifficultyObjects.Length)];
        this.selectedHole = randomlySelected;
    }

    public int GetLevelID()
    {
        return this.levelID;
    }

    public void SetLevelID(int levelID)
    {
        this.levelID = levelID;
    }

    public string GetLevelDifficulty()
    {
        return this.levelDifficulty;
    }

    public void SetLevelDifficulty(string levelDifficulty)
    {
        this.levelDifficulty = levelDifficulty;
    }

    public float GetTimeLimit()
    {
        return this.timeLimit;
    }

    public void SetTimeLimit(float timeLimit)
    {
        this.timeLimit = timeLimit;
    }

}

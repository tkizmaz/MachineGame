using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelHolder
{
    public List<Level> levels;
}

[System.Serializable]
public class Level
{
    public int levelID;
    public string levelDifficulty;
    public int timeLimit;
    public GameObject selectedHole;

    public GameObject GetSelectedHole()
    {
        GameObject[] holesByDifficulty = GameObject.FindGameObjectsWithTag(this.levelDifficulty);
        GameObject selectedHoleByDifficulty = holesByDifficulty[Random.Range(0, holesByDifficulty.Length)];
        return selectedHoleByDifficulty;
    }

}

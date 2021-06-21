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
        if(levelDifficulty == "Easy")
        {
            selectedHole = HoleHolder.instance.FindEasyHole();
        }

        else if(levelDifficulty == "Medium")
        {
            selectedHole = HoleHolder.instance.FindMediumHole();
        }

        else
        {
            selectedHole = HoleHolder.instance.FindHardHole();
        }

        return selectedHole;
    }

}

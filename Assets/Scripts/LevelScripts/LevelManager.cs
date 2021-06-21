using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private string levelsJSONURL = "https://drive.google.com/uc?export=download&id=1cQHqbfSFwVFhfvuzMmsHiOh3IoWtLe92";
    private List<Level> levelList;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }

        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    public void SetLevelList(List<Level> levelList)
    {
        this.levelList = levelList;
    }

    public List<Level> GetLevelList() 
    {
        return this.levelList;
    }

    private void Start()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        UnityWebRequest request = UnityWebRequest.Get(levelsJSONURL);
        yield return request.SendWebRequest();

        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }

        else
        {
            LevelHolder levelHolder = JsonUtility.FromJson<LevelHolder>(request.downloadHandler.text);
            SetLevelList(levelHolder.levels);
        }

    }


}

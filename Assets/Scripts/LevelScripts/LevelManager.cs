using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LevelManager : MonoBehaviour
{
    private string levelsJSONURL = "https://drive.google.com/uc?export=download&id=1cQHqbfSFwVFhfvuzMmsHiOh3IoWtLe92";

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
            GameManager.instance.SetLevelList(levelHolder.levels);
        }

    }


}

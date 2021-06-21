using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private Text levelText;
    [SerializeField] private Text timeText;

    private void Awake()
    {
        instance = this;
    }

    private void UpdateTimeText()
    {
        timeText.text = TimeController.instance.getTime().ToString();
    }

    public void UpdateLevelText(int level)
    {
        Debug.Log(level);
        levelText.text = level.ToString();
    }

    private void Start()
    {
        TimeController.instance.setTime(60f);
    }


    void Update()
    {
        TimeController.instance.BeginCountdown();
        //remove from update.
        UpdateTimeText();
    }
}

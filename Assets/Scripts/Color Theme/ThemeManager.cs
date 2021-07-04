using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeManager : MonoBehaviour
{
    #region Variables
    public static Action<Color> ThemeChanged;
    private Color hexColor;
    #endregion

    #region Unity's functions
    private void Start()
    {
        if (PlayerPrefs.GetString("ThemeColor") != null)
        {
            ChangeTheme(PlayerPrefs.GetString("ThemeColor"));
        }
    }
    #endregion

    #region Public functions
    public void ChangeTheme(string hexCode) 
    {
        if (ColorUtility.TryParseHtmlString(hexCode, out hexColor))
        {
            ThemeChanged?.Invoke(hexColor);
            PlayerPrefs.SetString("ThemeColor", hexCode);
        }
    }
    #endregion
}

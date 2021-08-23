using UnityEngine;
using UnityEngine.UI;

public class ThemeElement : MonoBehaviour
{
    #region Unity's functions
    private void Awake()
    {
        ThemeManager.ThemeChanged += ChangeColor;
    }

    private void OnDestroy()
    {
        ThemeManager.ThemeChanged -= ChangeColor;
    }
    #endregion

    #region Private functions
    private void ChangeColor(Color newColor) 
    {
        if (GetComponent<SpriteRenderer>() != null)
        {
            GetComponent<SpriteRenderer>().color = newColor;
        }
        else if (GetComponent<Image>() != null) 
        {
            GetComponent<Image>().color = newColor;
        }
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ToggleDarkMode()
    {
        ThemeGen.CurrentTheme.IsDarkMode = !ThemeGen.CurrentTheme.IsDarkMode;
        ThemeGen.LoadTheme();
    }
}

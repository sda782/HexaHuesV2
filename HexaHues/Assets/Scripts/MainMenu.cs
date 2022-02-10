using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private TitleBackground titleBackground;
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ToggleDarkMode()
    {
        ThemeGen.CurrentTheme.IsDarkMode = !ThemeGen.CurrentTheme.IsDarkMode;
        ThemeGen.LoadTheme();
    }

    public void SwitchTheme()
    {
        ThemeGen.SwitchTheme();
        titleBackground.UpdateColors();

    }
}

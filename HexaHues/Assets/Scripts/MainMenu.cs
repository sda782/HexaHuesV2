using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private TitleBackground titleBackground;
    [SerializeField]
    private GameObject settingPanel;
    [SerializeField]
    private GameObject settingButton;
    [SerializeField]
    private GameObject playButton;
    void Start()
    {
        settingPanel.SetActive(false);
        playButton.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }
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
    public void ToggleSetting()
    {
        settingPanel.SetActive(!settingPanel.activeSelf);
        settingButton.SetActive(!settingButton.activeSelf);
        playButton.SetActive(!playButton.activeSelf);
    }
}

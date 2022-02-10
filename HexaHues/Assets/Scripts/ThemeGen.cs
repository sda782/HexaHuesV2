using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ThemeGen : MonoBehaviour
{
    private static List<ColorTheme> themes;
    private static ColorTheme currentTheme;
    public static ColorTheme CurrentTheme { get => currentTheme; }
    void Awake()
    {
        if (themes == null)
        {
            themes = new List<ColorTheme>();
            setup_colors();
            currentTheme = GetTheme("Neon");
        }
        LoadTheme();
    }

    public void SetTheme(string name)
    {
        currentTheme = GetTheme(name);
    }

    public ColorTheme GetTheme(string name)
    {
        return themes.Find(t => t.Name == name);
    }

    public static void LoadTheme()
    {
        foreach (var cam in Camera.allCameras)
        {
            cam.backgroundColor = currentTheme.BackgroundColor;
        }
        Text[] texts = FindObjectsOfType<Text>();
        foreach (var text in texts)
        {
            text.color = currentTheme.TextColor;
        }
        Button[] btns = FindObjectsOfType<Button>();
        foreach (var btn in btns)
        {
            btn.image.color = currentTheme.BackgroundColor;
        }
    }

    private void setup_colors()
    {
        themes.Add(new ColorTheme()
        {
            Name = "Neon",
            Colors = new List<Color>() {
                new Color(1, 0.5529412f, 0),
                new Color(0.1058824f, 0.003921569f, 0.3647059f),
                new Color(1, 0, 0.654902f),
                new Color(0.1294118f, 1, 0.145098f),
                new Color(0.1254902f, 0.8039216f, 1) }
        });
        themes.Add(new ColorTheme()
        {
            Name = "Pastel",
            Colors = new List<Color>() {
                new Color(1, 0.7019608f, 0.7294118f),
                new Color(1, 0.8745098f, 0.7294118f),
                new Color(1, 1, 0.7294118f),
                new Color(0.7254902f, 1, 0.7882353f),
                new Color(0.7294118f, 0.8823529f, 1)
            }
        });
        themes.Add(new ColorTheme()
        {
            Name = "RGBYM",
            Colors = new List<Color>() {
                Color.red,
                Color.green,
                Color.blue,
                Color.yellow,
                Color.magenta }
        });
        themes.Add(new ColorTheme()
        {
            Name = "Monochrome",
            Colors = new List<Color>() {
                new Color(0.9f, 0.9f, 0.9f),
                new Color(0.675f, 0.675f, 0.675f),
                new Color(0.45f, 0.45f, 0.45f),
                new Color(0.225f, 0.225f, 0.225f),
                new Color(0, 0, 0)
            }
        });

        themes = themes.OrderBy(t => t.Name).ToList();
    }
}

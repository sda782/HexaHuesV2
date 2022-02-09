using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
public class ColorTheme
{
    public string Name { get; set; }
    public List<Color> Colors { get; set; }
    public bool IsDarkMode = false;
    private Color color_dark = new Color(18 / 255, 18 / 255, 18 / 255);
    public Color BackgroundColor { get => IsDarkMode ? color_dark : Color.white; }
    public Color TextColor { get => IsDarkMode ? Color.white : color_dark; }
    public Color GetRandomColor { get => Colors[Random.Range(0, Colors.Count)]; }
}

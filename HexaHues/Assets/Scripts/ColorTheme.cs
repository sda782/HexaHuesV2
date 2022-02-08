using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
public class ColorTheme
{
    public string Name { get; set; }
    public List<Color> Colors { get; set; }
    public bool IsDarkMode = false;
    public Color BackgroundColor { get => IsDarkMode ? Color.black : Color.white; }
    public Color TextColor { get => IsDarkMode ? Color.white : Color.black; }
    public Color GetRandomColor { get => Colors[Random.Range(0, Colors.Count)]; }
}

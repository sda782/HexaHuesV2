using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ColorTheme
{
    public string Name { get; set; }
    public List<Color> Colors { get; set; }
    public Color GetRandomColor { get => Colors[Random.Range(0, Colors.Count)]; }
}

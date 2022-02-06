using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static int score;
    private static int lives = 3;
    [SerializeField]
    private Text text_score;
    [SerializeField]
    private Text text_lives;

    public void AddPoint(bool isSameColor)
    {
        if (!isSameColor) return;
        score++;
        text_score.text = $"{score} : score";
    }
    public void RemoveLife(bool isSameColor)
    {
        if (lives <= 0) return;
        if (isSameColor) return;
        lives--;
        text_lives.text = $"Lives : {lives}";
    }
}

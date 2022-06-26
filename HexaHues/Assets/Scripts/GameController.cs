using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static int score;
    private static int lives;
    [SerializeField]
    private GameObject[] livesUI;
    [SerializeField]
    private Text text_score;
    private Text text_lives;
    [field: SerializeField]
    public UnityEvent GameOver;

    void Start()
    {
        lives = 3;
        foreach (var life in livesUI)
        {
            life.SetActive(true);
        }
    }

    public void AddPoint(bool isSameColor)
    {
        if (!isSameColor) return;
        score++;
        text_score.text = $"{score}P";
    }
    public void RemoveLife(bool isSameColor)
    {
        if (lives <= 0) return;
        if (isSameColor) return;
        lives--;
        livesUI[lives].SetActive(false);
        if (lives == 0) GameOver?.Invoke();
    }
}

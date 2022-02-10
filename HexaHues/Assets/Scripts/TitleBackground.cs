using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBackground : MonoBehaviour
{
    [SerializeField]
    private GameObject cell;
    private List<GameObject> cells;
    private float speed = 5;
    void Start()
    {
        cells = new List<GameObject>();
        for (int i = 0; i < 25; i++)
        {
            GameObject c = Instantiate(cell);
            SpriteRenderer sr = c.GetComponent<SpriteRenderer>();
            sr.color = ThemeGen.CurrentTheme.Colors[i % 5];
            c.transform.position = GetPosToSpawn();
            cells.Add(c);
        }
    }

    private Vector2 GetPosToSpawn()
    {
        float rx = Screen.width;
        return new Vector2(Random.Range(0, 6), Random.Range(-5, 6));
    }

    void Update()
    {
        foreach (GameObject c in cells)
        {
            c.transform.position = new Vector2(c.transform.position.x, c.transform.position.y <= -5 ? Random.Range(4, 7) : c.transform.position.y - Time.deltaTime * speed);
        }
    }

    public void UpdateColors()
    {
        for (int i = 0; i < 25; i++)
        {
            SpriteRenderer sr = cells[i].GetComponent<SpriteRenderer>();
            sr.color = ThemeGen.CurrentTheme.Colors[i % 5];
        }
    }
}

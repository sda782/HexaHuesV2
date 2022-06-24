using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TitleBackground : MonoBehaviour
{
    [SerializeField]
    private GameObject cell;
    private List<GameObject> cells;
    private float speed = 5;
    private float Height = 4;
    private float Width = 7.1f;
    void Start()
    {
        if (Screen.width < Screen.height) Width = 4 / 1.7777777f;
        cells = new List<GameObject>();
        for (int i = 0; i < 50; i++)
        {
            GameObject c = Instantiate(cell);
            c.AddComponent(typeof(CircleCollider2D));
            c.AddComponent(typeof(Rigidbody2D));
            c.GetComponent<Rigidbody2D>().gravityScale = 0;
            SpriteRenderer sr = c.GetComponent<SpriteRenderer>();
            sr.color = ThemeGen.CurrentTheme.Colors[i % 5];
            c.transform.position = GetRandomPointInBound();
            cells.Add(c);
        }
    }

    private Vector2 GetRandomPointInBound()
    {

        return new Vector2(Random.Range(-Width, Width), Random.Range(-Height, Height));
    }

    void Update()
    {
        foreach (GameObject c in cells)
        {
            Vector2 dir = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
            Rigidbody2D rb = c.GetComponent<Rigidbody2D>();
            rb.AddForce(dir);
            if (!isInside(c.transform.position)) rb.velocity = -rb.velocity;
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

    private bool isInside(Vector2 pos)
    {
        bool inside = true;
        if (pos.x <= -Width || pos.x >= Width) inside = false;
        if (pos.y <= -Height || pos.y >= Height) inside = false;
        return inside;
    }
}

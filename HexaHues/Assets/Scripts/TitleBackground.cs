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
    private float Width = 4;
    void Start()
    {
        Width = 4 / 1.7777777f;
        Debug.Log($"{Width}, {Height}");
        cells = new List<GameObject>();
        for (int i = 0; i < 40; i++)
        {
            GameObject c = Instantiate(cell);
            c.AddComponent(typeof(CircleCollider2D));
            c.AddComponent(typeof(Rigidbody2D));
            c.GetComponent<Rigidbody2D>().gravityScale = 0;
            SpriteRenderer sr = c.GetComponent<SpriteRenderer>();
            sr.color = ThemeGen.CurrentTheme.Colors[i % 5];
            //c.transform.position = GetPosToSpawn();
            c.transform.position = GetRandomPointInBound();
            cells.Add(c);
        }
    }

    private Vector2 GetRandomPointInBound()
    {

        return new Vector2(Random.Range(-Width, Width), Random.Range(-Height, Height));
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
            Vector2 dir = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
            Rigidbody2D rb = c.GetComponent<Rigidbody2D>();
            rb.AddForce(dir);
            if (!isInside(c.transform.position)) rb.velocity = -rb.velocity;

            //c.transform.position = new Vector2(c.transform.position.x, c.transform.position.y <= -5 ? Random.Range(4, 7) : c.transform.position.y - Time.deltaTime * speed);
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

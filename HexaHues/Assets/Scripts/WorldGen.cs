using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class WorldGen : MonoBehaviour
{
    [SerializeField]
    private float cellSize = 1f;
    [SerializeField]
    private float cellOffset = 1.2f;
    [SerializeField]
    private GameObject cell;

    [SerializeField]
    private int grid_size;
    private List<GameObject> cells;
    private WorldController worldController;
    private ThemeGen themeGen;
    [SerializeField]
    private PlayerController playerController;

    void Start()
    {
        worldController = GetComponent<WorldController>();
        themeGen = GetComponent<ThemeGen>();
        cells = new List<GameObject>();
        setWorld();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextLevel();
        }
    }

    private void nextLevel()
    {
        grid_size += 2;
        transform.position = Vector2.zero;
        foreach (var cell in cells)
        {
            Destroy(cell);
        }
        setWorld();
    }

    private void setWorld()
    {
        cells.Clear();
        spawn_grid();
        Vector2 worldSize = new Vector2(grid_size * cellSize, grid_size * cellSize);
        worldController.GenWorldBorder(worldSize);
        worldController.SetGround(worldSize);
        playerController.SetPlayerColor(getRandomColorFromPlatform());
        worldController.SetCamSize(Screen.width > Screen.height ? grid_size * 3 : grid_size * 5);
    }

    private void spawn_grid()
    {
        Vector2 pos = Vector2.zero;
        for (int i = 0; i < grid_size; i++)
        {
            for (int j = 0; j < grid_size; j++)
            {
                pos.y = i * cellSize * cellOffset;
                pos.x = j * cellSize * cellOffset;
                GameObject spawned_cell = Instantiate(cell, new Vector3(pos.x, pos.y, 10), cell.transform.rotation);
                spawned_cell.transform.localScale = Vector3.one * cellSize;
                spawned_cell.transform.SetParent(transform);
                setPlatformColor(spawned_cell);
                //  Add to list of cells
                cells.Add(spawned_cell);
            }
        }
        float globalOffsetX = (grid_size / 2) * cellSize * cellOffset;
        float globalOffsetY = (grid_size / 2) * cellSize * cellOffset;
        transform.position = new Vector2(-globalOffsetX, -globalOffsetY);
    }

    private void setPlatformColor(GameObject platform)
    {
        SpriteRenderer sr = platform.GetComponent<SpriteRenderer>();
        sr.color = themeGen.CurrentTheme.GetRandomColor;
    }
    private Color getRandomColorFromPlatform()
    {
        if (cells.Count == 0) return themeGen.CurrentTheme.Colors[0];
        if (cells.Count == 1) return cells[0].GetComponent<SpriteRenderer>().color;
        SpriteRenderer cellSR = cells[Random.Range(0, cells.Count)].GetComponent<SpriteRenderer>();
        return cellSR.color;
    }

    private bool IsSameColor(GameObject cell, GameObject player)
    {
        if (cell.GetComponent<SpriteRenderer>().color == player.GetComponent<SpriteRenderer>().color) return true;
        return false;
    }

    public void DestoryPlatform(GameObject player)
    {
        if (cells.Count <= 1)
        {
            Debug.Log("NextLEVEL");
            nextLevel();
            return;
        }
        GameObject toremove = Player_in_cell(player.transform);
        if (!IsSameColor(toremove, player)) return;
        cells.Remove(toremove);
        Destroy(toremove);
        playerController.SetPlayerColor(getRandomColorFromPlatform());
    }
    public GameObject Player_in_cell(Transform player_transform)
    {
        float dist = 0;
        float min_dist = grid_size * cellSize * 2;
        GameObject temp_obj = cells[0];
        foreach (GameObject cell in cells)
        {
            dist = Vector3.Distance(player_transform.position, cell.transform.position);
            if (dist < min_dist)
            {
                min_dist = dist;
                temp_obj = cell;
            }
        }
        return temp_obj;
    }
}
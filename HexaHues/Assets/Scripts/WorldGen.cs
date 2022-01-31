using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    [SerializeField]
    private float cellSize = 1f;
    [SerializeField]
    private GameObject cell;

    [SerializeField]
    private int grid_size;
    [SerializeField]
    private float squareness = 1.5f;
    private List<GameObject> cells;
    public List<GameObject> GridCells { get => cells; }
    private WorldController worldController;

    void Start()
    {
        worldController = GetComponent<WorldController>();
        cells = new List<GameObject>();
        setWorld();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            grid_size += 2;
            transform.position = Vector2.zero;
            foreach (var cell in cells)
            {
                Destroy(cell);
            }
            setWorld();
        }
    }

    private void setWorld()
    {
        cells.Clear();
        spawn_grid();
        Vector2 worldSize = new Vector2(grid_size * cellSize, grid_size * cellSize);
        worldController.GenWorldBorder(worldSize);
        worldController.SetGround(worldSize);
    }

    private void spawn_grid()
    {
        Vector2 pos = Vector2.zero;
        for (int i = 0; i < grid_size; i++)
        {
            for (int j = 0; j < grid_size; j++)
            {
                pos.y = i * cellSize;
                pos.x = j * cellSize;
                GameObject spawned_cell = Instantiate(cell, new Vector3(pos.x, pos.y, 10), cell.transform.rotation);
                spawned_cell.transform.localScale = Vector3.one * cellSize;
                spawned_cell.transform.SetParent(transform);
                //  Add to list of cells
                cells.Add(spawned_cell);
            }
        }
        //  Offset so middle is at 0,0

        //  FIX OFF SET FOR ALL SIZES

        float globalOffsetX = (grid_size + (grid_size - 1) / 2);
        float globalOffsetY = (grid_size + (grid_size - 1) / 2);
        Debug.Log($"GX {globalOffsetX}, GY {globalOffsetY}");
        transform.position = new Vector2(-globalOffsetX, -globalOffsetY);
    }

}

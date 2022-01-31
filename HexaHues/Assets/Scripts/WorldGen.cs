using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    [SerializeField]
    private float offset = 1.5f;
    [SerializeField]
    private GameObject cell;

    [SerializeField]
    private int grid_size;
    private List<GameObject> cells;
    public List<GameObject> GridCells { get => cells; }

    void Start()
    {
        cells = new List<GameObject>();
        spawn_grid();
    }

    private void spawn_grid()
    {
        Vector2 pos = Vector2.zero;
        float offset2 = cell.transform.localScale.magnitude * offset;
        for (int i = 0; i < grid_size; i++)
        {
            for (int j = 0; j < grid_size * 1.5f; j++)
            {
                pos.y = i * offset2;
                pos.x = j * offset2;
                GameObject spawned_cell = Instantiate(cell, new Vector3(pos.x, pos.y, 10), cell.transform.rotation);
                spawned_cell.transform.localScale = Vector3.one * offset;
                //  Add to list of cells
                cells.Add(spawned_cell);
            }
        }

    }

}

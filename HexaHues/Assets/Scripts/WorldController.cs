using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    [SerializeField]
    private int worldBorder;
    [SerializeField]
    private GameObject borderObj;
    [SerializeField]
    private GameObject groundObj;
    void Start()
    {
        genWorldBorder(10);
        genWorldBorder(0);
        int groundSize = worldBorder * 2;
        groundObj.transform.localScale = new Vector2(groundSize, groundSize);
    }

    void genWorldBorder(int offset)
    {
        GameObject border = Instantiate(borderObj);
        LineRenderer line = border.GetComponent<LineRenderer>();
        line.SetPosition(0, new Vector2(-worldBorder - offset, -worldBorder - offset));
        line.SetPosition(1, new Vector2(worldBorder + offset, -worldBorder - offset));
        line.SetPosition(2, new Vector2(worldBorder + offset, worldBorder + offset));
        line.SetPosition(3, new Vector2(-worldBorder - offset, worldBorder + offset));
        //line.SetPosition(4, new Vector2(-worldBorder, -worldBorder));
    }
    public bool OutSideBorder(Vector2 val, Vector2 mouse_val)
    {
        return ((val.x <= -worldBorder || val.x >= worldBorder) && (mouse_val.x <= -worldBorder || mouse_val.x >= worldBorder))
        || ((val.y <= -worldBorder || val.y >= worldBorder) && (mouse_val.y <= -worldBorder || mouse_val.y >= worldBorder));
    }
    /* public bool OutSideBorder(Vector2 val, Vector2 mouse_val)
    {
        bool isoutside = false;
        if ((val.x <= -worldBorder || val.x >= worldBorder) && (mouse_val.x <= -worldBorder || mouse_val.x >= worldBorder)) isoutside = true;
        if ((val.y <= -worldBorder || val.y >= worldBorder) && (mouse_val.y <= -worldBorder || mouse_val.y >= worldBorder)) isoutside = true;
        return isoutside;
    } */
}

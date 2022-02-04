using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    private Vector2 worldBorder;
    [SerializeField]
    private GameObject borderObj;
    [SerializeField]
    private GameObject groundObj;

    public void GenWorldBorder(Vector2 size)
    {
        size /= 1.5f;
        LineRenderer line = borderObj.GetComponent<LineRenderer>();
        line.SetPosition(0, new Vector2(-size.x, -size.y));
        line.SetPosition(1, new Vector2(size.x, -size.y));
        line.SetPosition(2, new Vector2(size.x, size.y));
        line.SetPosition(3, new Vector2(-size.x, size.y));
        worldBorder = size;
    }

    public void SetGround(Vector2 size)
    {
        size *= 2;
        groundObj.transform.localScale = size;
    }
    public bool OutSideBorder(Vector2 val, Vector2 mouse_val)
    {
        return ((val.x <= -worldBorder.x || val.x >= worldBorder.x) && (mouse_val.x <= -worldBorder.x || mouse_val.x >= worldBorder.x))
        || ((val.y <= -worldBorder.y || val.y >= worldBorder.y) && (mouse_val.y <= -worldBorder.y || mouse_val.y >= worldBorder.y));
    }
    /* public bool OutSideBorder(Vector2 val, Vector2 mouse_val)
    {
        bool isoutside = false;
        if ((val.x <= -worldBorder || val.x >= worldBorder) && (mouse_val.x <= -worldBorder || mouse_val.x >= worldBorder)) isoutside = true;
        if ((val.y <= -worldBorder || val.y >= worldBorder) && (mouse_val.y <= -worldBorder || mouse_val.y >= worldBorder)) isoutside = true;
        return isoutside;
    } */
}

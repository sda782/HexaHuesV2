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
    private ParticleSystem pSystem;
    private ParticleSystem.MainModule main;
    void Start()
    {
        main = pSystem.main;
    }

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

    public void SetCamSize(float size)
    {
        Camera.main.orthographicSize = size;
    }

    public bool OutSideBorder(Vector2 val, Vector2 mouse_val)
    {
        return ((val.x <= -worldBorder.x || val.x >= worldBorder.x) && (mouse_val.x <= -worldBorder.x || mouse_val.x >= worldBorder.x))
        || ((val.y <= -worldBorder.y || val.y >= worldBorder.y) && (mouse_val.y <= -worldBorder.y || mouse_val.y >= worldBorder.y));
    }

    public void SpawnParticle(Vector3 cell, Color color)
    {
        main.startColor = color;
        pSystem.gameObject.transform.position = cell;
        pSystem.Play();
    }
    /* public bool OutSideBorder(Vector2 val, Vector2 mouse_val)
    {
        bool isoutside = false;
        if ((val.x <= -worldBorder || val.x >= worldBorder) && (mouse_val.x <= -worldBorder || mouse_val.x >= worldBorder)) isoutside = true;
        if ((val.y <= -worldBorder || val.y >= worldBorder) && (mouse_val.y <= -worldBorder || mouse_val.y >= worldBorder)) isoutside = true;
        return isoutside;
    } */
}

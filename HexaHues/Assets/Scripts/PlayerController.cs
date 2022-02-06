using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    public UnityEvent<GameObject> RemovePlatform;
    [field: SerializeField]
    private TrailRenderer tr;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) TriggerPlatform();
    }

    private void TriggerPlatform()
    {
        RemovePlatform?.Invoke(gameObject);
    }
    public void SetPlayerColor(Color color)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        tr.startColor = color;
        tr.endColor = color;
        sr.color = color;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    public UnityEvent<GameObject> RemovePlatform;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("trigger");
            TriggerPlatform();
        }
    }

    private void TriggerPlatform()
    {
        RemovePlatform?.Invoke(gameObject);
    }
    public void SetPlayerColor(Color color)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = color;
    }
}

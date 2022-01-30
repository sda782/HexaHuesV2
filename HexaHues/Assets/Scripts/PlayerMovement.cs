using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
    }
    void FixedUpdate()
    {
        Drag();
    }

    private void Drag()
    {
        if (rb.velocity.magnitude > 30) rb.velocity = rb.velocity.normalized * 30;
        if (rb.velocity.magnitude <= 0.05f)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        rb.velocity *= 0.95f;
    }

    void Move()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dir = (worldPosition - transform.position);
            if (dir.magnitude <= 1f) return;
            rb.AddForce(dir.normalized * speed * 100, ForceMode2D.Impulse);
        }

    }
}

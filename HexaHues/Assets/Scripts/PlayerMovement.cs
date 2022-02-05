using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int speed;
    [SerializeField]
    private int maxSpeed;

    [SerializeField]
    private WorldController worldController;
    private Rigidbody2D rb;
    private float dragFallOff = 0.9f;

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
        if (rb.velocity.magnitude > maxSpeed) rb.velocity = rb.velocity.normalized * maxSpeed;
        if (rb.velocity.magnitude <= 0.05f)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        rb.velocity *= dragFallOff;
    }

    void Move()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (worldController.OutSideBorder(transform.position, worldPosition)) return;
            Vector3 dir = (worldPosition - transform.position);
            if (dir.magnitude <= 0.1f) return;
            rb.AddForce(dir.normalized * speed * 100, ForceMode2D.Impulse);
        }
    }
}

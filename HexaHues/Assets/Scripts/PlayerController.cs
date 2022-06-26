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
    private Rigidbody2D rb;
    private bool timerStarted;
    private float timer;
    [SerializeField]
    private GameObject TimerIndicator;
    void Start()
    {
        timerStarted = false;
        timer = 0;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //for 2 finger touch input
        /* if (Input.touchCount == 2)
        {
            Touch touch = Input.GetTouch(1);
            if (touch.phase == TouchPhase.Began) TriggerPlatform();

        } */
        //for mouse input
        //if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) TriggerPlatform();

        // for timerbased control
        if (rb.velocity == Vector2.zero)
        {
            if (!timerStarted)
            {
                timerStarted = true;
                timer = 0;
                TimerIndicator.transform.localScale = Vector2.one;
            }
            else
            {
                timer += Time.deltaTime;
                TimerIndicator.transform.localScale += new Vector3(0.001f, 0.001f, 0);
            }
            if (timer >= 1)
            {
                TriggerPlatform();
                timer = 0;
                TimerIndicator.transform.localScale = Vector2.one;
                timerStarted = false;
            }
        }
        else
        {
            timerStarted = false;
            TimerIndicator.transform.localScale = Vector2.one;
        }
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
        TimerIndicator.GetComponent<SpriteRenderer>().color = color;
    }
}

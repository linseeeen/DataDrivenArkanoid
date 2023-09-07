using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed = 1;
    private Vector2 velocity = Vector2.down;

    private Vector2 direction;

    public Player PlayerObj;

    public float HeightAbovePaddle = 1;

    private SpriteRenderer spriteRenderer;

    public BallPowerUp BallPowerUpType;

    public GameObject Parrent;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = velocity;
    }   

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            direction = transform.position - col.transform.position;
            velocity = direction.normalized * speed;
        }
        else if(col.gameObject.CompareTag("Wall") || col.gameObject.CompareTag("Brick"))
        {
            direction = Vector2.Reflect(direction, col.contacts[0].normal);
            velocity = direction.normalized * speed;
        }
        else if(col.gameObject.CompareTag("Brick"))
        {
            direction = Vector2.Reflect(direction, col.contacts[0].normal);
            velocity = direction.normalized * speed;
        }
    }
}

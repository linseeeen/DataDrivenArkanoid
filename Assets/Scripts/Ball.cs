using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private Vector2 velocity;

    private Vector2 direction;

    private float HeightAbovePaddle = 1;
    private float speed;

    private SpriteRenderer spriteRenderer;

    public BallScriptObj BallType;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        speed = BallType.Speed;
        HeightAbovePaddle = BallType.HeightAbovePaddle;
        velocity = BallType.StartAngle;
        spriteRenderer.sprite = BallType.BallSprite;
        Physics.IgnoreLayerCollision(3, 3);
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
        else if (col.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Ball : MonoBehaviour
{
    public static event EventHandler OnBallInstans;
    public static event EventHandler OnBallDestroy;
    private Rigidbody2D rb;
    
    private Vector2 BallVelocity = Vector2.zero;

    private Vector2 direction;

    private float HeightAbovePaddle = 1;
    private float speed;

    private SpriteRenderer spriteRenderer;

    public BallScriptObj BallType;
    private bool gameRunning = false;
    public bool FirstBall = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        speed = BallType.Speed;
        HeightAbovePaddle = BallType.HeightAbovePaddle;
        
        spriteRenderer.sprite = BallType.BallSprite;
        rb.velocity = BallVelocity;
        if (!FirstBall)
        {
            BallVelocity = BallType.StartAngle;
        }
        OnBallInstans?.Invoke(this, EventArgs.Empty);
    }

    private void OnEnable()
    {
        Player.OnStart += StartGame;
    }

    private void OnDisable()
    {
        Player.OnStart -= StartGame;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 parentPosition = Vector3.zero;
        if(transform.parent != null) parentPosition = transform.parent.transform.position;
        if(!FirstBall || gameRunning)
        {
            rb.velocity = BallVelocity;
        }
        else if(FirstBall)
        {
            this.transform.position = new Vector2(parentPosition.x, parentPosition.y + HeightAbovePaddle);
        }
        
        
    }   

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            direction = transform.position - col.transform.position;
            BallVelocity = direction.normalized * speed;
        }
        else if(col.gameObject.CompareTag("Wall") || col.gameObject.CompareTag("Brick"))
        {
            direction = Vector2.Reflect(direction, col.contacts[0].normal);
            BallVelocity = direction.normalized * speed;
        }/*
        else if(col.gameObject.CompareTag("Brick"))
        {
            direction = Vector2.Reflect(direction, col.contacts[0].normal);
            BallVelocity = direction.normalized * speed;
        }*/
        else if (col.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
            OnBallDestroy?.Invoke(this, EventArgs.Empty);
        }
    }

    private void StartGame(object sender, EventArgs e)
    {
        if (!gameRunning)
        {
            transform.parent = null;
            BallVelocity = BallType.StartAngle;
            gameRunning = true;
        }
    }
}

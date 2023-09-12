using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    //Runs when a ball is created.
    public static event EventHandler OnBallInstans;
    //Runs when a ball is destroyed.
    public static event EventHandler OnBallDestroy;
    
    [Tooltip("The scriptableobject containing the data about what kind of brick this should be.")]
    public BallScriptObj BallType;
    [Tooltip("Checked if this is the first ball created")]
    public bool FirstBall = false;
    
    
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private AudioSource audio;
    
    private Vector2 BallVelocity = Vector2.zero;
    private Vector2 direction;

    //Set in the scriptableObject
    private float HeightAbovePaddle = 1;
    private float speed;

    private bool gameRunning = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        speed = BallType.Speed;
        HeightAbovePaddle = BallType.HeightAbovePaddle;
        
        spriteRenderer.sprite = BallType.BallSprite;
        
        
        //IF this is not the first ball created then it should be moving instantly
        if (!FirstBall)
        {
            BallVelocity = Random.insideUnitCircle  * speed;
            direction = BallVelocity;
        }
        rb.velocity = BallVelocity;
        OnBallInstans?.Invoke(this, EventArgs.Empty);
        audio = GetComponent<AudioSource>();
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
            audio.Play();
        }
        else if(col.gameObject.CompareTag("Wall") || col.gameObject.CompareTag("Brick"))
        {
            Vector2 contact = Vector2.zero;
            int contactsAmount = col.GetContacts(new List<ContactPoint2D>());
            Debug.Log(contactsAmount);
            for (int i = 0; i < contactsAmount; i++)
            {
                contact += col.GetContact(i).normal;
            }

            contact /= contactsAmount;
            
            direction = Vector2.Reflect(direction, contact);
            BallVelocity = direction.normalized * speed;
            audio.Play();
        }
        else if (col.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
            OnBallDestroy?.Invoke(this, EventArgs.Empty);
        }
    }

    private void StartGame(object sender, EventArgs e)
    {
        if (transform.parent != null)
        {
            transform.parent = null;
            BallVelocity = BallType.StartAngle;
            gameRunning = true;
        }
    }
}

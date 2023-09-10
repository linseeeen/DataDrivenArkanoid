using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
//Execute always so that changes made to this obj appears in editor as well.
[ExecuteAlways]
public class CapsuleManager : MonoBehaviour
{
    public Sprite PrefabSprite;
    public PowerUp PowerUpType;
    public float Speed = 1;
    
    private SpriteRenderer spriterenderer;

    private float speed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        spriterenderer.sprite = PrefabSprite;
        Move();
    }

    void Move()
    {
        Vector2 velocity = Vector2.down;
        velocity *= speed;
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
}

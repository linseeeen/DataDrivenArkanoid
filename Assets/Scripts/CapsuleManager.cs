using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
//Execute always so that changes made to this obj appears in editor as well.
[ExecuteAlways]
public class CapsuleManager : MonoBehaviour
{
    public CapsuleScriptObj CapsuleType;
    
    private SpriteRenderer spriterenderer;

    private float speed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        speed = CapsuleType.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        spriterenderer.sprite = CapsuleType.PrefabSprite;
        Move();
    }

    void Move()
    {
        Vector2 velocity = Vector2.down;
        velocity *= speed;
        rb.velocity = velocity;
    }

}

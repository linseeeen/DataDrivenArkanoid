using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
//Execute always so that changes made to this obj appears in editor as well.
[ExecuteAlways]
public class CapsuleManager : MonoBehaviour
{
    [Tooltip("The sprite of the capsule")]
    public Sprite PrefabSprite;
    [Tooltip("The type of powerup for this capsule.")]
    public PowerUp PowerUpType;
    [Tooltip("How fast the capsule should fall.")]
    public float Speed = 1;

    public string PowerUpName
    {
        get { return PowerUpType.Name; }
    }
    private SpriteRenderer spriterenderer;

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
        velocity *= Speed;
        rb.velocity = velocity;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
}

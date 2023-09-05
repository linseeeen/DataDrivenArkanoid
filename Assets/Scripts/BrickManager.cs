using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Execute always in order for the sprite to show up in the editor. To make changes easier.
[ExecuteAlways]
[RequireComponent(typeof(SpriteRenderer))]
public class BrickManager : MonoBehaviour
{
    public Brick BrickType;
    private SpriteRenderer spriteRenderer;
    private int health;

    
    // Start is called before the first frame update
    void Start()
    {
        name = BrickType.Prefabname;
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = BrickType.Health;
    }

    // Update is called once per frame
    void Update()
    {
        if (BrickType == null) {
            Debug.LogWarning("BrickManager is missing a BrickType. Please add a BrickType");
        }
        else
        {
            spriteRenderer.sprite = BrickType.PrefabSprite;
        }

        if (health <= 0 && BrickType.Destructable)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            health--;
            Debug.Log("hit");
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

//Execute always in order for the sprite to show up in the editor. To make changes easier.
[ExecuteAlways]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class BrickManager : MonoBehaviour
{
    public Brick BrickType;
    private SpriteRenderer spriteRenderer;
    private int health;
    private Random random = new Random();

    
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
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            health--;
            Debug.Log("hit");
            if(BrickType.PossiblePowerUps.Count > 0)
            {
                for (int i = 0; i < BrickType.PossiblePowerUps.Count; i++)
                {
                    float chance = BrickType.PowerUpSpawnPossibility;
                    chance *= 100;
                    int rand = random.Next(0, 100);
                    if (rand <= chance)
                    {
                        Instantiate(BrickType.PossiblePowerUps[i], this.transform.position, this.transform.rotation);
                        Debug.Log("Powerup spawnar woo!");
                        break;
                    }

                }
                
            }
            
            
            if (BrickType.NextBrick != null) BrickType = BrickType.NextBrick;
        }
    }
}

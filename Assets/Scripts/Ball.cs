using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed = 1;
    private Vector2 velocity = Vector2.down;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = velocity;
    }   

    private void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 bounce;
        if (col.gameObject.CompareTag("Player"))
        {
            bounce = transform.position - col.transform.position;
            velocity = bounce.normalized * speed;
        }
        else
        {
            //use .Reflect to studsa bollen, bollen har ingen velocity i studsen
        }
    }
}

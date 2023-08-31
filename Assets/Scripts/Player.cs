using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject Paddle;
    private Vector3 paddlePosition;
    
    
    
    //ska innehålla paddeln ?
    // Start is called before the first frame update
    void Start()
    {
        paddlePosition = Paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void Move()
    {
        Paddle.transform.position = paddlePosition * Time.deltaTime;
    }

    private void GetInput()
    {
        if (Input.GetKey("a"))
        {
            
        }
    }
}

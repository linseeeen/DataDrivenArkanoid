using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    [SerializeField] GameObject Paddle;
    private Vector3 paddlePosition;
    [SerializeField] private int speed = 1;
    [SerializeField] private Input _input;
    private PlayerInput _playerInput;



    //ska innehålla paddeln ?
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<Input>();
        _playerInput = GetComponent<PlayerInput>();
        paddlePosition = Paddle.transform.position;
        if (speed <= 0)
        {
            Debug.LogWarning("Speed is set to 0 or less, change to positive value.", this);
        }
    }

    
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float xAxis = _input.move.x;
        paddlePosition.x = xAxis * paddlePosition.x * speed * Time.deltaTime;
        Paddle.transform.position = paddlePosition;
    }

}

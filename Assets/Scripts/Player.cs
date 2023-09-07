using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;



[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    public event EventHandler<OnBallPowerUpEventArgs> OnBallPowerUp;

    public class OnBallPowerUpEventArgs : EventArgs
    {
        public PowerUp EnabledPowerUp;
    }
    
    [SerializeField] GameObject Paddle;
    protected Vector3 paddlePosition;
    [SerializeField] protected float speed = 1;
    public List<Transform> Walls;
    private CustomInput _input;
    private Vector2 move = Vector2.zero;
    private Rigidbody2D rb;
    public int Health = 1;

    private PowerUp powerUp;

    public bool gameStarted;
    void Awake() {
        _input = new CustomInput();
        rb = GetComponent<Rigidbody2D>();
        
    }

    //ska innehålla paddeln ?
    // Start is called before the first frame update
    

    private void OnEnable() {
        _input.Enable();
        _input.Player.Move.performed += OnMove;
        _input.Player.Move.canceled += OnMoveCancelled;
        
    }

    private void OnDisable() {
        _input.Disable();
        _input.Player.Move.performed -= OnMove;
        _input.Player.Move.canceled -= OnMoveCancelled;
        
    }

    void FixedUpdate() {
        Move();
    }

    private void Move() {
        rb.velocity = move * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Vector3 positionNow = this.transform.position;
        if (other.gameObject.CompareTag("Wall")){
            this.transform.position = positionNow;
        }
    } 

    private void OnMove(InputAction.CallbackContext value) {
        move = value.ReadValue<Vector2>();
    }


    //TODO: kolla om denna verkligen behövs
    private void OnMoveCancelled(InputAction.CallbackContext value){
        move = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Colliding with PowerUp");
        //Checks if not null
        if (col.gameObject.CompareTag("Capsule"))
        {
            GameObject capsule = col.gameObject;
            CapsuleManager capsuleM = capsule.GetComponent<CapsuleManager>();
            powerUp = capsuleM.CapsuleType.PowerUpType;
            OnBallPowerUp?.Invoke(this, new OnBallPowerUpEventArgs{EnabledPowerUp = powerUp});
        }
        
    }
}

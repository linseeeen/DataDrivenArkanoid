using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    public static event EventHandler<OnPowerUpEventArgs> OnPowerUp;
    public static event EventHandler OnStart; 

    public class OnPowerUpEventArgs : EventArgs
    {
        public string EnabledPowerUp;
        public Vector3 playerPosition;
        public GameObject paddel;
    }
    [Tooltip("The first ball")]
    public GameObject BallPrefab;
    [Tooltip("Players speed")]
    public float speed = 1;
    
    private CustomInput _input;
    private AudioSource audio;
    private Rigidbody2D rb;

    private string powerUp;
    private Vector2 move = Vector2.zero;

    

    void Awake() {
        _input = new CustomInput();
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    //ska innehålla paddeln ?
    // Start is called before the first frame update
    

    private void OnEnable() {
        _input.Enable();
        _input.Player.Move.performed += OnMove;
        _input.Player.Move.canceled += OnMoveCancelled;
        
        _input.Player.StartGame.performed += OnStartGame;

        RestartScript.OnHealthLoss += NewBall;
    }

    private void OnDisable() {
        _input.Disable();
        _input.Player.Move.performed -= OnMove;
        _input.Player.Move.canceled -= OnMoveCancelled;
        
        _input.Player.StartGame.performed -= OnStartGame;
        RestartScript.OnHealthLoss -= NewBall;
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

    private void OnStartGame(InputAction.CallbackContext value)
    {
        OnStart?.Invoke(this, EventArgs.Empty);
    }

    private void NewBall(object sender, EventArgs e)
    {
        Instantiate(BallPrefab, this.transform).GetComponent<Ball>().FirstBall = true;
        Debug.Log("New Ball Spawning!");
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        Debug.Log("Colliding with PowerUp");
        //Checks if not null
        if (col.gameObject.CompareTag("Capsule"))
        {
            GameObject capsule = col.gameObject;
            CapsuleManager capsuleM = capsule.GetComponent<CapsuleManager>();
            powerUp = capsuleM.PowerUpName;
            OnPowerUp?.Invoke(this, new OnPowerUpEventArgs{EnabledPowerUp = powerUp, playerPosition = transform.position, paddel = this.gameObject});
            Destroy(capsule);
            audio.Play();
        }
    }

}

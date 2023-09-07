using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private int childNumber;
    private int instanceNumber = 0;
    
    public Player player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        player.OnBallPowerUp += SpawnBall;
    }

    private void OnDisable()
    {
        player.OnBallPowerUp -= SpawnBall;
    }

    // Update is called once per frame
    void Update()
    {
        childNumber = transform.childCount;
    }

    private void SpawnBall(object sender, Player.OnBallPowerUpEventArgs e)
    {
        PowerUp powerUp = e.EnabledPowerUp;

        if (powerUp.GetType() == typeof(BallPowerUp))
        {
            Debug.Log("BallPowerUp!");
        }
        
        Debug.Log("Event has reached me");
    }
}

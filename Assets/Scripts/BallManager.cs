using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private int childNumber;
    private int instanceNumber = 0;
    
    public Player player;
    
    private void OnEnable()
    {
        player.OnPowerUp += SpawnBall;
    }

    private void OnDisable()
    {
        player.OnPowerUp -= SpawnBall;
    }

    // Update is called once per frame
    void Update()
    {
        childNumber = transform.childCount;
    }

    private void SpawnBall(object sender, Player.OnPowerUpEventArgs e)
    {
        PowerUp powerUp = e.EnabledPowerUp;

        if (powerUp.GetType() == typeof(BallPowerUp))
        {
            Debug.Log("BallPowerUp!");
        }
        
        //Debug.Log("Event has reached me");
    }
}

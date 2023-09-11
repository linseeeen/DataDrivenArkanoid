using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartScript : MonoBehaviour
{
    public static event EventHandler OnHealthLoss; 
    
    [Tooltip("TextObject for displaying points")]
    public TMP_Text points;
    [Tooltip("TextObject for displaying health")]
    public TMP_Text health;
    
    [Tooltip("The 'winLose' object for this scene.")]
    public WinLose data;
    [Tooltip("The players health")]
    public int Health = 3;
    
    private int pointsInt = 0;
    private int Balls = 0;
    private int Bricks = 0;
    
    

    private void Start()
    {
        health.text = "Health: " + Health;

        points.text = "Points: " + pointsInt;
    }

    void Update()
    {
        Debug.Log(Bricks);
        if (Bricks == 0)
        {
            data.winLose = "You Won!";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        //TODO: gör så att den automatiskt räknar hur många scener som finns och tar en till slutet
        if (Balls == 0)
        {
            if (Health > 0)
            {
                OnHealthLoss?.Invoke(this, EventArgs.Empty);
                Health--;
                Debug.Log(Health);
            }
            else
            {
                data.winLose = "You Lost!";
                data.Points = pointsInt;
                SceneManager.LoadScene(3);
            }
        }

        health.text = "Health: " + Health;

        points.text = "Points: " + pointsInt;
    }

    private void OnEnable()
    {
        Ball.OnBallInstans += BallAdd;
        Ball.OnBallDestroy += BallRemove;
        BrickManager.OnBrickInstans += BrickAdd;
        BrickManager.OnBrickDestroy += BrickRemove;
    }

    private void OnDisable()
    {
        Ball.OnBallInstans -= BallAdd;
        Ball.OnBallDestroy -= BallRemove;
        BrickManager.OnBrickInstans -= BrickAdd;
        BrickManager.OnBrickDestroy -= BrickRemove;
    }

    private void BallAdd(object sender, EventArgs e)
    {
        Balls++;
    }

    private void BallRemove(object sender, EventArgs e)
    {
        Balls--;
    }
    private void BrickAdd(object sender, EventArgs e)
    {
        Bricks++;
    }

    private void BrickRemove(object sender, BrickManager.OnBrickDestroyEventArgs e)
    {
        pointsInt += e.Points;
        Bricks--;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    private int Balls = 0;
    private int Bricks = 0;
    public WinLose data;
    void Update()
    {using UnityEngine.SceneManagement;
        if (Balls == 0)
        {
            data.winLose = "You Lost!";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

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

    private void BrickRemove(object sender, EventArgs e)
    {
        Bricks--;
    }
}
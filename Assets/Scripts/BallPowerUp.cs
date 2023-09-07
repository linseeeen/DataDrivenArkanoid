using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ball", menuName = "Arkanoid/PowerUp/BallPowerUp", order = 1)]
public class BallPowerUp : PowerUp
{
    public string Name = "NewBall";
    public Sprite PrefabSprite;
    public Vector2 StartAngle = Vector2.down;
    //public Vector2 EndAngle; //Behövs denna?
    public int AmountOfBalls = 1;
    public float Speed = 1;
    
    private void Awake()
        {
            if (PrefabSprite == null)
            {
                Debug.LogWarning("Missing sprite in " + Name, this);
            }
            if(AmountOfBalls < 1)
            {
                Debug.LogWarning("There needs to be at least 1 ball", this);
                AmountOfBalls = 1;
            }

            if (Speed <= 0)
            {
                Debug.LogWarning("Speed needs to be bigger than 0");
                Speed = 1;
            }
        }
}

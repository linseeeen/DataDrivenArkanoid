using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ball", menuName = "Arkanoid/PowerUp/BallPowerUp", order = 1)]
public class BallPowerUp : PowerUp
{
    //public string Name = "NewBallPowerUp";
    //public Sprite PrefabSprite;
    //public Vector2 EndAngle; //Behövs denna?
    public int AmountOfBalls = 1;
    public GameObject BallPrefab;
    private SpriteRenderer spriteRenderer;
    private Vector3 size;


    private void Awake()
    {
        if (BallPrefab == null)
        {
            Debug.LogWarning("Missing sprite in " + Name, this);
        }

        if (AmountOfBalls < 1)
        {
            Debug.LogWarning("There needs to be at least 1 ball", this);
            AmountOfBalls = 1;
        }

        
    }

    private void OnEnable()
    {
        Player.OnPowerUp += SpawnBall;
        spriteRenderer = BallPrefab.GetComponent<SpriteRenderer>();
        size = spriteRenderer.bounds.size;
    }

    private void OnDisable()
    {
        Player.OnPowerUp -= SpawnBall;
    }
    //TODO: bollarna behöver spawna med lite olika vinklar så att de inte är i varandra
    private void SpawnBall(object sender, Player.OnPowerUpEventArgs e)
    {
        string powerUp = e.EnabledPowerUp;
        if (Name == powerUp)
        {
            for (int i = 0; i < AmountOfBalls; i++)
            {
                Vector3 position = new Vector3(e.playerPosition.x + (size.x * i), e.playerPosition.y + 1,
                    e.playerPosition.z);
                Instantiate(BallPrefab, position, BallPrefab.transform.rotation);
            }
        }
        
        //Debug.Log("Event has reached me");
    }
}

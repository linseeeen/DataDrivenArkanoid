using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ball", menuName = "Arkanoid/Ball", order = 2)]
public class BallPowerUp : ScriptableObject
{
    public string Name = "NewBall";
    public Sprite PrefabSprite;
    public Vector2 StartAngle = Vector2.down;
    public Vector2 EndAngle; //Behövs denna?
    public int Amount;
    
    private void Awake()
        {
            if (PrefabSprite == null)
            {
                Debug.LogWarning("Missing sprite in " + Name, PrefabSprite);
            }
        }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Ball", menuName = "Arkanoid/Ball", order = 4)]
public class BallScriptObj : ScriptableObject
{
    public float Speed = 1;
    public float HeightAbovePaddle = 1;
    public Vector2 StartAngle = Vector2.down;
    public Sprite BallSprite;
}

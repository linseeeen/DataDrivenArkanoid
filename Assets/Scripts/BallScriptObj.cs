using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Ball", menuName = "Arkanoid/Ball", order = 4)]
public class BallScriptObj : ScriptableObject
{
    [Tooltip("THe speed of the ball.")]
    public float Speed = 1;
    [Tooltip("How high above the paddel the ball should spawn.")]
    public float HeightAbovePaddle = 1;
    [Tooltip("The angle the first ball should move.")]
    public Vector2 StartAngle = Vector2.down;
    [Tooltip("The balls sprite.")]
    public Sprite BallSprite;
}
